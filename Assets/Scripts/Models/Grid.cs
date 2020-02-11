using System.Collections.Generic;

public class Grid
{
    private Base[,] _grid;

    public int Width { get; }
    public int Height { get; }

    public Grid(int width, int height)
    {
        Width = width;
        Height = height;

        _grid = new Base[Width, Height];
    }

    public Base this[int i, int j] 
    {
        get => _grid[i, j];
        set => _grid[i, j] = value;
    }

    public Base this[(int i, int j) position] 
    {
        get => this[position.i, position.j];
        set => this[position.i, position.j] = value;
    }

    public IEnumerable<(int, int)> Corners {
        get {
            yield return (0, 0);
            yield return (0, Height - 1);
            yield return (Width - 1, 0);
            yield return (Width - 1, Height - 1);
        }
    }
}
