using System;
using System.Collections.Generic;
using System.Linq;

public class Base
{
    private Dictionary<Unit.Type, int> _army;

    private Resourсes _resources;

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

        _resources.Goods = Settings.Initial.Resourсes.Goods;
        _resources.People = Settings.Initial.Resourсes.People;
        _resources.Credits = Settings.Initial.Resourсes.Credits;
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
        _resources.Credits += Settings.Production.CreditsPerPerson * _resources.People + Portals.Sum(x => x.Income);
        _resources.People += Settings.Production.PeoplePerStep + Modules.Sum(x => x.PopulationGrowth);
        _resources.Goods += Settings.Production.GoodsPerStep + Factories.Sum(x => x.Production);
    }

    public void Expand()
    {
        if (!_resources.IsEnough(Settings.Expand.Price))
            throw new Exception("You do not have enough resources.");

        _resources.Substract(Settings.Expand.Price);

        Buildings.Add(new ResidentialModule());
        Buildings.Add(new Workshop());

        foreach (var wall in Walls)
            wall.Expand();
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
                //if (!Resources.IsEnough(building.UpgradePrice()))
                //    throw new Exception("You do not have enough resources.");

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
                var trainedNumber = units.Sum(x => x.Value);
                var trainPrice = Settings.Train.Price.Multiply(trainedNumber);

                if (!_resources.IsEnough(trainPrice))
                    throw new Exception("You do not have enough resources.");

                if (trainedNumber + UnitNumber() > UnitLimit())
                    throw new Exception("Exceeding the limit of units!");

                foreach (var unit in units)
                    _army[unit.Key] += unit.Value;

                building.Trained();
            }
        }
    }

    public void Buy(int count)
    {
        var purchasePrice = Portals.Sum(x => x.PurchasePrice);

        if (_resources.Credits < purchasePrice * count)
            throw new Exception("You do not have enough credits.");

        _resources.Credits -= count * purchasePrice;
        _resources.Goods += count;
    }

    public void Sell(int count)
    {
        if (_resources.Goods < count)
            throw new Exception("You do not have enough goods.");

        _resources.Credits += count * Portals.Sum(x => x.SalePrice);
        _resources.Goods -= count;
    }

    private int UnitNumber() =>
        _army.Sum(x => x.Value);

    public int PopulationLimit() =>
        Modules.Sum(x => x.PopulationLimit);

    public int UnitLimit() =>
        Barracks.Sum(x => x.UnitLimit);

    public Resourсes Resourсes() =>
        _resources;
}
