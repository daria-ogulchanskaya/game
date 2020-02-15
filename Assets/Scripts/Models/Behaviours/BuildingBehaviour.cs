using System;
using System.Linq;

namespace Assets.Scripts.Models.Behaviours
{
    public class BuildingBehaviour : Behaviour
    {
        private readonly Random _random = new Random();

        public void Step(Base @base, Game game)
        {
            var probability = _random.Next(0, 101);

            if (@base.Resources.IsEnough(Settings.Expand.Price))
                if (game.Grid.CanExpand(@base))
                    game.Grid.Expand(@base);

            if (25 < probability && probability <= 60)
                Upgrade(@base);

            if (probability <= 10)
                Attack(@base, game);

            if (10 < probability && probability <= 25)
                Train(@base);
        }

        private void Train(Base @base)
        {
            var count = @base.Resources.Divide(Settings.Train.Price) / 5;
            var army = new Army();

            var price = Settings.Train.Price;
            price.Multiply(count);

            army.Add(Unit.Type.Attack, count);

            if (@base.Resources.IsEnough(price) && @base.Army.Count + army.Count < @base.UnitLimit())
                @base.StartTrain(army);
        }

        private void Attack(Base @base, Game game)
        {
            var enemies = game.Bases.Where(x => x != @base).ToList();
            var target = enemies[_random.Next(0, enemies.Count)];

            @base.Army.Attack();
        }

        private void Upgrade(Base @base)
        {
            var probability = _random.Next(0, 101);

            if (probability <= 10)
            {
                foreach (var building in @base.Barracks)
                    if (@base.Resources.IsEnough(building.UpgradePrice()))
                        building.LevelUp();
            }
            if (10 < probability && probability <= 25)
            {
                foreach (var building in @base.Modules)
                    if (@base.Resources.IsEnough(building.UpgradePrice()))
                        building.LevelUp();
            }
            if (25 < probability && probability <= 50)
            {
                foreach (var building in @base.Workshops)
                    if (@base.Resources.IsEnough(building.UpgradePrice()))
                        building.LevelUp();
            }
            if (50 < probability && probability <= 70)
            {
                foreach (var building in @base.Portals)
                    if (@base.Resources.IsEnough(building.UpgradePrice()))
                        building.LevelUp();
            }
        }
    }
}
