using System;
using System.Collections.Generic;
using System.Linq;

public class Base
{
    private Resources _resources;

    public Army Army { get; }
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

        Army = new Army();

        _resources.Goods = Settings.Initial.Resourсes.Goods;
        _resources.People = Settings.Initial.Resourсes.People;
        _resources.Credits = Settings.Initial.Resourсes.Credits;
    }

    public IEnumerable<IFactory> Factories =>
        Buildings.OfType<IFactory>();

    public IEnumerable<ResidentialModule> Modules =>
        Buildings.OfType<ResidentialModule>();

    public IEnumerable<Portal> Portals =>
         Buildings.OfType<Portal>();

    public IEnumerable<Barracks> Barracks =>
        Buildings.OfType<Barracks>();

    public IEnumerable<Walls> Walls =>
        Buildings.OfType<Walls>();

    public IEnumerable<Workshop> Workshops =>
        Buildings.OfType<Workshop>();

    public void Produce()
    {
        var credits = Settings.Production.CreditsPerPerson * _resources.People + Portals.Sum(x => x.Income);
        var people = Settings.Production.PeoplePerStep + Modules.Sum(x => x.PopulationGrowth);
        var goods = Settings.Production.GoodsPerStep + Factories.Sum(x => x.Production);

        _resources.Credits += credits;
        _resources.People += people;
        _resources.Goods += goods;

        if (_resources.People > PopulationLimit())
            _resources.People = PopulationLimit();
    }

    public void Expand()
    {
        if (!_resources.IsEnough(Settings.Expand.Price))
            throw new Exception("You do not have enough resources.");

        _resources.Subtract(Settings.Expand.Price);

        Buildings.Add(new ResidentialModule());
        Buildings.Add(new Workshop());

        foreach (var wall in Walls)
            wall.Expand();
    }

    public virtual void Step()
    {
        Produce();
        FinishUpgrade();
        FinishTrain();
    }

    public void StartUpgrade(Building building)
    {
        if (!_resources.IsEnough(building.UpgradePrice()))
            throw new Exception("You do not have enough resources.");

        _resources.Subtract(building.UpgradePrice());

        building.Upgrading = true;
    }

    public void FinishUpgrade()
    {
        foreach (var building in Buildings)
            if (building.Upgrading)
                building.LevelUp();
    }

    public void StartTrain(Army army)
    {
        var price = Settings.Train.Price.Clone();

        price.Multiply(army.Count);

        if (!_resources.IsEnough(price))
            throw new Exception("You do not have enough resources.");
        if (army.Count + Army.Count > UnitLimit())
            throw new Exception("Exceeding the limit of units!");

        _resources.Subtract(price);

        foreach (var barracks in Barracks)
            barracks.Train(army);
    }

    public void FinishTrain()
    {
        foreach (var building in Barracks)
        {
            if (!building.Training)
                continue;

            var units = building.Army;
            var count = units.Count;
            var price = Settings.Train.Price.Clone();

            price.Multiply(count);

            Army.Add(units);

            building.Trained(this);
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

    public int PopulationLimit() =>
        Modules.Sum(x => x.PopulationLimit);

    public int UnitLimit() =>
        Barracks.Sum(x => x.UnitLimit);

    public bool CanDefendAgainst(Army enemyArmy) =>
        Army.Defence() > enemyArmy.Attack();

    public Resources Resources =>
        _resources;
}
