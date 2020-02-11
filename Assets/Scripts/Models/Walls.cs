public class Walls : Building
{
    public double Defence { get; private set; }

    public override void Upgrade() =>
        Upgrading = true;

    public override void LevelUp()
    {
        Defence += Settings.Upgrade.WallDefenceIncreace;
        Upgrading = false;
        ++Level;
    }

    public void LevelDown()
    {
        if (Level <= Settings.Expand.WallLevelDecrease)
            Level = 1;
        else
            Level -= Settings.Expand.WallLevelDecrease;
    }
}
