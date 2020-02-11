using UnityEngine;

class GridComponent : MonoBehaviour
{
    public GameObject EmptyTile;
    public GameObject PlayerTile;
    public GameObject EnemyTile;

    private float _tileSize = 1;

    public Grid Grid { get; set; }

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        GameObject tile;

        for (int i = 0; i < Grid.Width; i++)
        {
            for (int j = 0; j < Grid.Height; j++)
            {
                if (Grid[i, j] != null)
                {
                    if (i == 0 && j == 0)
                    {
                        tile = Instantiate(PlayerTile, transform);
                        var playerComponent = tile.AddComponent<PlayerComponent>();
                        playerComponent.Base = Grid[i, j];
                    }
                    else
                        tile = Instantiate(EnemyTile, transform);
                }
                else
                    tile = Instantiate(EmptyTile, transform);

                tile.name = "Tile" + "[" + i + ", " + j + "]";
                tile.transform.position = new Vector2(j * _tileSize, i * -_tileSize);
            }
        }
    }
}
