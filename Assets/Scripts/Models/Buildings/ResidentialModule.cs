public class ResidentialModule : Building
{
    public ResidentialModule()
    {
        PopulationLimit = Settings.Initial.PopulationLimit;
    }

    public double PopulationGrowth { get; private set; }
    public int PopulationLimit { get; private set; }

    public override void LevelUp()
    {
        PopulationGrowth += Settings.Upgrade.PopulationGrowthIncrease;
        PopulationLimit += Settings.Upgrade.PopulationLimitIncrease;
        Upgrading = false;
        ++Level;
    }
}
