using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class GridComponent : MonoBehaviour
{
    public GameObject Tile, BaseTile, EnemyTile;
    public Grid Grid { get; set; } 
    private float _tileSize = 1;

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
                        tile = Instantiate(BaseTile, transform);
                        var playerComponent = tile.AddComponent<PlayerComponent>();
                        playerComponent.Base = Grid[i, j];
                    }
                    else
                        tile = Instantiate(EnemyTile, transform);
                }
                else
                    tile = Instantiate(Tile, transform);

                tile.name = "Tile" + "[" + i + ", " + j + "]";
                tile.transform.position = new Vector2(j * _tileSize, i * -_tileSize);
            }
        }
    }
}
