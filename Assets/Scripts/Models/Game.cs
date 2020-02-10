using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Game
{
    public Grid Grid { get; }
    public List<Base> Bases { get; }

    public Game(int width, int height, int enemies)
    {
        Grid = new Grid(width, height);
        Bases = new List<Base>();

        for (var i = 0; i < enemies + 1; ++i)
        {
            var @base = new Base();
            var corner = Grid.Corners[i];

            Bases.Add(@base);
            Grid[corner] = @base;
        }
    }
}
