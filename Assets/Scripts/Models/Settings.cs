public static class Settings
{
    public static class Initial
    {
        public static Resourсes Resourсes = new Resourсes(500, 300, 200);
        public static double PurchasePriсe = 1.5;
        public static double SalePriсe = 0.5;
        public static int PopulationLimit = 1000;
    }

    public static class Production
    {
        public const double PeoplePerStep = 100;
        public const double GoodsPerStep = 100;
        public const double CreditsPerPerson = 0.1;
    }

    public static class Expand
    {
        public static Resourсes Price = new Resourсes(1000, 1000, 500);
        public const int WallLevelDecrease = 5;
    }

    public static class Upgrade
    {
        public const int UnitLimitIncrease = 100;
        public const int PopulationLimitIncreace = 200;
        public const double UnitDefenceIncrease = 0.1;
        public const double UnitAttackIncrease = 0.1;
        public const double PopulationGrowthIncreace = 0.5 / 100;
        public const double PortalProductionIncreace = 0.25 / 100;
        public const double WorkshopProductionIncreace = 1.75 / 100;
        public const double IncomeIncrease = 0.25 / 100;
        public const double WallDefenceIncreace = 0.05;
    }

    public static class Train
    {
        public static Resourсes Price = new Resourсes(10, 10, 1);
    }

    public static class Units
    {
        public static Skills Parameters(Unit.Type type)
        {
            if (type == Unit.Type.Attack)
                return new Skills(2, 5, 1);
            else if (type == Unit.Type.Defence)
                return new Skills(2, 2, 4);
            else 
                return new Skills(4, 3, 1);
        }
    }
}

