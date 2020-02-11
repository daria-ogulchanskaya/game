using UnityEngine;

public class GridComponent : MonoBehaviour
{
    public GameObject PlayerTile;
    public GameObject EnemyTile;
    public GameObject EmptyTile;

    public Grid Grid;

    private void Start() =>
        GenerateGrid();

    private void GenerateGrid()
    {
        for (int x = 0; x < Grid.Width; x++)
        for (int y = 0; y < Grid.Height; y++)
        {
            var tile = Place(x, y);

            tile.name = $"Tile[{x}, {y}]";
            tile.transform.position = new Vector2(x, y);
        }

        GameObject Place(int x, int y)
        {
            var tile = Grid[x, y];
            if (tile == null)
                return Instantiate(EmptyTile, transform);

            // Player's base is always in the bottom left corner.
            if (x == 0 && y == 0)
            {
                var @object = Instantiate(PlayerTile, transform);
                var player = @object.AddComponent<PlayerComponent>();

                player.Base = Grid[x, y];

                return @object;
            }
            else
                return Instantiate(EnemyTile, transform);
        }
    }
}
