// See https://aka.ms/new-console-template for more information

using CraftingHelper.Config;

public class FakeCraft : CraftBase
{
    private Random random = new Random();

    public FakeCraft(Config config) : base(config)
    {
    }

    protected override void ApplyCurrency(string currency)
    {
        // move mouse and click..
    }

    protected override bool CheckOutcome(Filter[] filters)
    {
        // faking every currency sucess with a 10% chance
        return random.Next(0, 10) == 3;
    }

}
