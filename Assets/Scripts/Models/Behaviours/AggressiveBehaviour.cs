using System;
using System.Linq;

namespace Assets.Scripts.Models.Behaviours
{
    public class AggressiveBehaviour : Behaviour
    {
        private readonly Random _random = new Random();

        public void Step(Base @base, Game game)
        {
            var probability = _random.Next(0, 101);

            Train(@base);

            if (@base.Army.Count >= 50 && probability < 70) 
                Attack(@base, game);

            Upgrade(@base);
        }

        private void Train(Base @base)
        {
            var count = @base.Resources.Divide(Settings.Train.Price) / 2;
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
         
            if (@base.Army.Count != 0)
                @base.Army.Attack();
        }

        private void Upgrade(Base @base)
        {
            foreach (var building in @base.Barracks)
                if (@base.Resources.IsEnough(Settings.Expand.Price))
                    building.LevelUp();
        }
    }
}
