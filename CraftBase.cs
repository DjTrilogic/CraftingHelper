// See https://aka.ms/new-console-template for more information

using CraftingHelper.Config;
using System.Collections;

public abstract class CraftBase
{
    private bool shouldStop;
    private Step? currentStep;
    private Dictionary<string, int> usedCurrency = new Dictionary<string, int>();
    private Dictionary<long, Step> Steps { get; }

    public CraftBase(Config config)
    {
        Config = config;
        Steps = config.ConfigConfig
        .Select((value, index) => new Step()
        {
            Index = index + 1,
            Actions = value.Actions,
            Autopass = value.Autopass,
            Filters = value.Filters,
            Method = value.Method,
            Mopts = value.Mopts,
            Vfilter = value.Vfilter,
        })
        .ToDictionary(pair => (long)pair.Index, pair => pair);
        currentStep = Steps.Values.FirstOrDefault();
    }

    public Config Config { get; }
    public Dictionary<string, int> UsedCurrency { get => usedCurrency; }

    public virtual void Stop()
    {
        shouldStop = true;
    }

    public IEnumerator Execute()
    {
        OnCraftStart();

        if (!CanDoCraft())
        {
            Console.WriteLine($"Wrong initial item: STOPPING...");
            yield break;
        }

        while (currentStep != null && !shouldStop)
        {
            if (!CanDoStep())
            {
                yield break;
            }

            currentStep = ExecuteStep(currentStep);
            yield return AfterEachStep();

        }

        Console.WriteLine($"Crafting finished\n{string.Join("\n", UsedCurrency.Select(c => $"{c.Key}: {c.Value}"))}");
        yield break;
    }

    protected virtual bool CanDoStep()
    {
        return true;
    }

    protected virtual void OnCraftStart()
    {

    }

    protected virtual void ReparseItem()
    {

    }

    private Step? ExecuteStep(Step step)
    {
        ApplyMethod(step.Method);
        ReparseItem();
        if (step.Autopass || CheckOutcome(step.Filters))
        {
            Console.WriteLine($"Step succeeeded");
            return NextAction(step.Actions.Win, step.Actions.WinRoute);
        }
        else
        {
            Console.WriteLine($"Step failed");
            return NextAction(step.Actions.Fail, step.Actions.FailRoute);
        }
    }

    private Step? NextAction(string action, long? route)
    {
        long? nextStep;
        switch (action)
        {
            case "step":
                nextStep = route.Value;
                break;
            case "loop":
            case "next":
                nextStep = currentStep.Index + 1;
                break;
            case "restart":
                nextStep = 1;
                break;
            default:
                throw new NotImplementedException();
        }

        if (!nextStep.HasValue || !Steps.ContainsKey(nextStep.Value))
        {
            return null;
        }


        Console.WriteLine($"Moving to step : {nextStep.Value}...");
        return Steps[nextStep.Value];
    }

    private bool CheckOutcome(Filter[] filters)
    {
        var passed = true;
        var passedGroups = 0;
        foreach (var filter in filters)
        {
            var passedConditions = 0;
            foreach (var condition in filter.Conds)
            {
                var mod = condition.Id;
                if (ItemHasMod(mod))
                {
                    passedConditions++;
                }
                else
                {
                    switch (mod)
                    {
                        case "open_prefix":
                            if (GetItemOpenPrefixes() >= condition.Treshold)
                            {
                                passedConditions++;
                            }
                            break;
                        case "open_suffix":
                            if (GetItemOpenSuffixes() >= condition.Treshold)
                            {
                                passedConditions++;
                            }
                            break;
                        // TODO: complete
                        default:
                            break;
                    }
                }
            }


            var requiredCondsCount = filter.Treshold.HasValue ? filter.Treshold.Value : filter.Conds.Length;
            switch (filter.Type)
            {
                case "or":
                    if (passedConditions >= requiredCondsCount)
                    {
                        passedGroups++;
                    }
                    break;
                case "and":
                    var needed = filter.Treshold.HasValue ? filter.Treshold.Value : filter.Conds.Length;
                    if (passedConditions >= requiredCondsCount)
                    {
                        passedGroups++;
                    }
                    else
                    {
                        passed = false;
                    }
                    break;
                default:
                    if (passedConditions > 0)
                    {
                        passed = false;
                    }
                    break;
            }
        }

        if (passedGroups == 0)
        {
            passed = false;
        }

        return passed;
    }


    private void ApplyMethod(string[] method)
    {
        switch (method[0])
        {
            case "currency":
                var currency = method[1];
                Console.WriteLine($"Applying currency: {currency}...");
                ApplyCurrency(currency);
                if (!UsedCurrency.ContainsKey(currency))
                {
                    UsedCurrency.Add(currency, 0);
                }
                UsedCurrency[currency]++;
                break;
            case "check":
                Console.WriteLine($"Checking item...");
                break;
        }
    }


    protected abstract bool CanDoCraft();
    protected abstract IEnumerator AfterEachStep();
    protected abstract long GetItemOpenSuffixes();
    protected abstract long GetItemOpenPrefixes();
    protected abstract bool ItemHasMod(string mod);
    protected abstract void ApplyCurrency(string currency);

    private class Step : ConfigElement
    {
        public int Index { get; set; }
    }
}
