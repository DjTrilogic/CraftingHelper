// See https://aka.ms/new-console-template for more information

using CraftingHelper.Config;

public abstract class CraftBase
{
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

    public void Execute()
    {
        while (currentStep != null)
        {
            currentStep = ExecuteStep(currentStep);
        }

        Console.WriteLine($"Crafting finished\n{string.Join("\n", usedCurrency.Select(c => $"{c.Key}: {c.Value}"))}");
    }

    private Step? ExecuteStep(Step step)
    {
        ApplyMethod(step.Method);
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
        long? nextStep = new Nullable<long>();
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

    protected abstract bool CheckOutcome(Filter[] filters);


    private void ApplyMethod(string[] method)
    {
        switch (method[0])
        {
            case "currency":
                var currency = method[1];
                Console.WriteLine($"Applying currency: {currency}...");
                ApplyCurrency(currency);
                if (!usedCurrency.ContainsKey(currency))
                {
                    usedCurrency.Add(currency, 0);
                }
                usedCurrency[currency]++;
                break;
            case "check":
                Console.WriteLine($"Checking item...");
                break;
        }
    }

    protected abstract void ApplyCurrency(string currency);

    private class Step : ConfigElement
    {
        public int Index { get; set; }
    }
}
