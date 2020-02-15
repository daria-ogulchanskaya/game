public class Barracks : Building
{
    public double UnitDefence { get; private set; }
    public double UnitAttack { get; private set; }
    public int UnitLimit { get; private set; }
    public bool Training { get; set; }
    public Army Army { get; private set; }

    public void Trained(Base @base)
    {
        Training = false;
        Army = null;
    }

    public override void LevelUp()
    {
        UnitLimit += Settings.Upgrade.UnitLimitIncrease;
        UnitDefence += Settings.Upgrade.UnitDefenceIncrease;
        UnitAttack += Settings.Upgrade.UnitAttackIncrease;
        Upgrading = false;
        ++Level;
    }

    public void Train(Army army)
    {
        Training = true;
        Army = army;
    }
}
