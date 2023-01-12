// See https://aka.ms/new-console-template for more information

using CraftingHelper.Config;
using System.Collections;


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

    protected override bool CanDoCraft()
    {
        return true;
    }

    protected override long GetItemOpenPrefixes()
    {
        return random.Next(0, 2);
    }

    protected override long GetItemOpenSuffixes()
    {
        return random.Next(0, 2);
    }

    protected override bool ItemHasMod(string mod)
    {
        // 10% for item to have the mod
        return random.Next(0, 10) == 3;
    }

    protected override IEnumerator AfterEachStep()
    {
        return null;
    }
}
