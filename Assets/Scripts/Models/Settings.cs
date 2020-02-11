using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Settings
{
    public static class Initial
    {
        public static Resourses Resourses = new Resourses(500, 300, 200);
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
        public static Resourses Price = new Resourses(1000, 1000, 500);
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
}

