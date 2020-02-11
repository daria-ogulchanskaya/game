using System.Collections.Generic;
using System.Linq;

public class Game
{
    public Grid Grid { get; }
    public List<Base> Bases { get; }

    public Game(int width, int height, int enemies)
    {
        Grid = new Grid(width, height);
        Bases = new List<Base>();

        foreach (var corner in Grid.Corners.Take(enemies + 1))
        {
            var @base = new Base();

            Bases.Add(@base);
            Grid[corner] = @base;
        }
    }
}
