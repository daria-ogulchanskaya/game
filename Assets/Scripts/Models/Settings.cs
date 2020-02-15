using System;

public static class Settings
{
    public static class Battle
    {
        public static Resources VictoryReward = 
            new Resources(credits: 1000, people: 0, goods: 1000);
    }

    public static class Initial
    {
        public static Resources Resourсes = 
            new Resources(credits: 500, people: 200, goods: 300);

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
        public static Resources Price = 
            new Resources(credits: 1000, people: 500, goods: 1000);

        public const int WallLevelDecrease = 5;
    }

    public static class Upgrade
    {
        public const int UnitLimitIncrease = 100;
        public const int PopulationLimitIncrease = 200;
        public const double UnitDefenceIncrease = 0.1;
        public const double UnitAttackIncrease = 0.1;
        public const double PopulationGrowthIncrease = 0.5 / 100;
        public const double PortalProductionIncrease = 0.25 / 100;
        public const double WorkshopProductionIncrease = 1.75 / 100;
        public const double IncomeIncrease = 0.25 / 100;
        public const double WallDefenceIncrease = 0.05;
    }

    public static class Train
    {
        public static Resources Price = 
            new Resources(credits: 10, people: 1, goods: 10);
    }

    public static class Units
    {
        public static Skills Parameters(Unit.Type type)
        {
            if (type == Unit.Type.Attack)
                return new Skills(attack: 5, defence: 1, speed: 2);
            if (type == Unit.Type.Defence)
                return new Skills(attack: 2, defence: 4, speed: 2);
            if (type == Unit.Type.Speed)
                return new Skills(attack: 3, defence: 1, speed: 4);

            throw new Exception($"Invalid unit type: {type}.");
        }
    }
}

