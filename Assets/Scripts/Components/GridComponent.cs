using Assets.Scripts.Models.Behaviours;
using System.Collections.Generic;
using UnityEngine;
public class GridComponent : MonoBehaviour
{
    public GameObject EmptyTile;
    public List<GameObject> ColoredTiles;
   
    public Grid Grid;
    public Game Game;

    private List<GameObject> _objects;

    private readonly System.Random _random = new System.Random();

    private void Start()
    {
        _objects = new List<GameObject>();

        Grid.Changed += UpdateGrid;
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        for (int x = 0; x < Grid.Width; x++)
        for (int y = 0; y < Grid.Height; y++)
        {
            var tile = Place(x, y);
            _objects.Add(tile);

            tile.name = $"Tile[{x}, {y}]";
            tile.transform.position = new Vector2(x, y);
        }

        GameObject Place(int x, int y)
        {
            var tile = Grid[x, y];
            int color = 0;

            if (tile == null)
                return Instantiate(EmptyTile, transform);

            for (int i = 0; i < Game.Bases.Count; i++)
                if (Game.Bases[i] == tile)
                    color = i;

            var @object = Instantiate(ColoredTiles[color], transform);

            // Player's base is always in the bottom left corner.
            if (tile == Game.Bases[0])
            {
                var player = @object.AddComponent<PlayerComponent>();
                player.Base = tile;

                var resourcesDisplayComponent = FindObjectOfType<ResourcesDisplayComponent>();
                resourcesDisplayComponent.Base = player.Base;

                var unitDisplayComponent = FindObjectOfType<UnitDisplayComponent>();
                unitDisplayComponent.Base = player.Base;

                return @object;
            }
            else
            {
                var enemy = @object.AddComponent<EnemyComponent>();
                enemy.Base = tile;
                enemy.Behaviour = PickBehaviour();

                return @object;
            }
        }
    }

    private void UpdateGrid()
    {
        foreach (var @object in _objects)
            Destroy(@object);

        GenerateGrid();
    }

    private Assets.Scripts.Models.Behaviours.Behaviour PickBehaviour()
    {
        var behaviours = new List<Assets.Scripts.Models.Behaviours.Behaviour>
        {
            new AggressiveBehaviour(),
            new BuildingBehaviour(),
            new TradingBehaviour()
        };

        return behaviours[_random.Next(0, 3)];
    }
}
