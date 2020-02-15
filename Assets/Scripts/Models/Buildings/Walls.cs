public class Walls : Building
{
    public double Defence { get; private set; }

    public override void LevelUp()
    {
        Defence += Settings.Upgrade.WallDefenceIncrease;
        Upgrading = false;
        ++Level;
    }

    public void Expand()
    {
        if (Level <= Settings.Expand.WallLevelDecrease)
            Level = 1;
        else
            Level -= Settings.Expand.WallLevelDecrease;
    }
}
