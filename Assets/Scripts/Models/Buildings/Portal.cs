class Portal : Building
{
    public double Production { get; private set; }
    public double PurchasePrice { get; private set; }
    public double SalePrice { get; private set; }
    public double Income { get; private set; }

    public Portal()
    {
        PurchasePrice = Settings.Initial.PurchasePriсe;
        SalePrice = Settings.Initial.SalePriсe;
    }

    public override void Upgrade() =>
        Upgrading = true;

    public override void LevelUp()
    {
        Production += Settings.Upgrade.PortalProductionIncreace;
        Income += Settings.Upgrade.IncomeIncrease;
        Upgrading = false;
        ++Level;
    }
}

