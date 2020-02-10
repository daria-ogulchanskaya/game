using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barracks : Building
{
    public double UnitDefence { get; private set; }
    public double UnitAttack { get; private set; }
    public int UnitLimit { get; private set; }
    public bool Training { get; private set; }
    public Dictionary<Unit.Type, int> Units { get; private set; }

    public override void Upgrade() =>
        Upgrading = true;

    public void Trained() =>
        Training = false;

    public override void LevelUp()
    {
        UnitLimit += Settings.Upgrade.UnitLimitIncrease;
        UnitDefence += Settings.Upgrade.UnitDefenceIncrease;
        UnitAttack += Settings.Upgrade.UnitAttackIncrease;
        Upgrading = false;
        ++Level;
    }

    public void Train(Dictionary<Unit.Type, int> units)
    {
        Training = true;
        Units = units;
    }
}
