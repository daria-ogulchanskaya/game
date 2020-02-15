using System;
using System.Collections.Generic;

public class Grid
{
    private readonly Base[,] _grid;

    public int Width { get; }
    public int Height { get; }

    public event Action Changed;

    public Grid(int width, int height)
    {
        Width = width;
        Height = height;

        _grid = new Base[Width, Height];
    }

    public Base this[int i, int j] 
    {
        get => _grid[i, j];
        set
        {
            _grid[i, j] = value;

            if (Changed != null)
                Changed();
        }
    }

    public Base this[(int i, int j) position] 
    {
        get => this[position.i, position.j];
        set => this[position.i, position.j] = value;
    }

    public IEnumerable<(int, int)> Corners
    {
        get
        {
            yield return (0, 0);
            yield return (0, Height - 1);
            yield return (Width - 1, 0);
            yield return (Width - 1, Height - 1);
        }
    }

    public IEnumerable<(int X, int Y)> Neighbours(int x, int y)
    {
        if (IsInRange(x + 1, y)) yield return (x + 1, y);
        if (IsInRange(x, y + 1)) yield return (x, y + 1);
        if (IsInRange(x - 1, y)) yield return (x - 1, y);
        if (IsInRange(x, y - 1)) yield return (x, y - 1);
    }

    private (int, int)? EmptyNeighbour(Base @base)
    {
        for (int x = 0; x < Width; x++)
        for (int y = 0; y < Height; y++)
            if (_grid[x, y] == @base)
                return Search(x, y, new HashSet<(int, int)>());

        return null;

        (int, int)? Search(int x, int y, HashSet<(int, int)> visited)
        {
            if (visited.Contains((x, y)))
                return null;

            visited.Add((x, y));

            foreach (var neighbour in Neighbours(x, y))
                if (this[neighbour] == null)
                    return neighbour;

            foreach (var neighbour in Neighbours(x, y))
            {
                if (this[neighbour] == @base)
                {
                    var found = Search(neighbour.X, neighbour.Y, visited);
                    if (found != null)
                        return found;
                }
            }

            return null;
        }
    }

    public void Expand(Base @base)
    {
        var position = EmptyNeighbour(@base);
        if (position != null)
        {
            @base.Expand();
            this[position.Value] = @base;
        }
    }

    public bool CanExpand(Base @base) =>
        EmptyNeighbour(@base) != null;

    public bool IsInRange((int X, int Y) position) => 
        IsInRange(position.X, position.Y);

    public bool IsInRange(int x, int y) =>
        0 <= x && x < Width &&
        0 <= y && y < Height;

    public void Remove(Base @base)
    {
        for (int x = 0; x < Width; x++)
        for (int y = 0; y < Height; y++)
            if (_grid[x, y] == @base)
                this[x, y] = null;
    }
}
