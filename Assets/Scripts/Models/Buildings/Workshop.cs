public class Workshop : Building
{
    public double Production { get; set; }

    public override void LevelUp()
    {
        Production += Settings.Upgrade.WorkshopProductionIncrease;
        Upgrading = false;
        ++Level;
    }
}
