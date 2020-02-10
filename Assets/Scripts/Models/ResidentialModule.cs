using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResidentialModule : Building
{
    public ResidentialModule()
    {
        PopulationLimit = 1000;
    }

    public double PopulationGrowth { get; private set; }
    public int PopulationLimit { get; private set; }

    public override void Upgrade() =>
        Upgrading = true;

    public override void LevelUp()
    {
        PopulationGrowth += Settings.Upgrade.PopulationGrowthIncreace;
        PopulationLimit += Settings.Upgrade.PopulationLimitIncreace;
        Upgrading = false;
        ++Level;
    }
}
