using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

class Base
{
    private Dictionary<Unit.Type, int> _army;
    public Resourses Resourses;

    public List<Building> Buildings { get; private set; }

    public Base()
    {
        Buildings = new List<Building>
            {
                new Barracks(),
                new Walls(),
                new Portal(),
                new Workshop(),
                new ResidentialModule()
            };

        _army = new Dictionary<Unit.Type, int>
            {
                { Unit.Type.Attack, 0 },
                { Unit.Type.Defence, 0 },
                { Unit.Type.Speed, 0 }
            };

        Resourses.Goods = Settings.Initial.Resourses.Goods;
        Resourses.People = Settings.Initial.Resourses.People;
        Resourses.Credits = Settings.Initial.Resourses.Credits;
    }

    IEnumerable<IFactory> Factories =>
        Buildings.OfType<IFactory>();

    IEnumerable<ResidentialModule> Modules =>
        Buildings.OfType<ResidentialModule>();

    IEnumerable<Portal> Portals =>
         Buildings.OfType<Portal>();

    IEnumerable<Barracks> Barracks =>
        Buildings.OfType<Barracks>();

    IEnumerable<Walls> Walls =>
        Buildings.OfType<Walls>();

    public void Produce()
    {
        Resourses.Credits += Settings.Production.CreditsPerPerson * Resourses.People + Portals.Sum(x => x.Income);
        Resourses.People += Settings.Production.PeoplePerStep + Modules.Sum(x => x.PopulationGrowth);
        Resourses.Goods += Settings.Production.GoodsPerStep + Factories.Sum(x => x.Production);
    }

    public int PopulationLimit() =>
        Modules.Sum(x => x.PopulationLimit);

    public int UnitLimit() =>
        Barracks.Sum(x => x.UnitLimit);

    public void Expand()
    {
        if (!Resourses.IsEnough(Settings.Expand.Price))
            throw new Exception("You do not have enough resources.");

        Resourses.Substract(Settings.Expand.Price);

        Buildings.Add(new ResidentialModule());
        Buildings.Add(new Workshop());

        foreach (var wall in Walls)
            wall.LevelDown();
    }

    public virtual void Step()
    {
        Produce();
        Upgrade();
        Train();
    }

    public void Upgrade()
    {
        foreach (var building in Buildings)
            if (building.Upgrading)
            {
                
                building.LevelUp();
            }
    }

    public void Train()
    {
        foreach (var building in Barracks)
        {
            if (building.Training)
            {
                var units = building.Units;

                if (units.Sum(x => x.Value) + _army.Sum(x => x.Value) > UnitLimit())
                    throw new Exception("Exceeding the limit of units!");

                foreach (var unit in units)
                    _army[unit.Key] += unit.Value;
            }

            building.Trained();
        }
    }

    public void Buy(int count)
    {
        var purchasePrice = Portals.Sum(x => x.PurchasePrice);

        if (Resourses.Credits < purchasePrice * count)
            throw new Exception("You do not have enough credits.");

        Resourses.Credits -= count * purchasePrice;
        Resourses.Goods += count;
    }

    public void Sell(int count)
    {
        if (Resourses.Goods < count)
            throw new Exception("You do not have enough goods.");

        Resourses.Credits += count * Portals.Sum(x => x.SalePrice);
        Resourses.Goods -= count;
    }
}
