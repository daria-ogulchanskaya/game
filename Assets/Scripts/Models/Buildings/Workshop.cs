public class Workshop : Building
{
    public double Production { get; set; }

    public override void Upgrade() =>
        Upgrading = true;

    public override void LevelUp()
    {
        Production += Settings.Upgrade.WorkshopProductionIncreace;
        Upgrading = false;
        ++Level;
    }
}
