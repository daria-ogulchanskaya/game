using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameComponent : MonoBehaviour
{
    private Game _game;
    public GameObject Grid;

    void Start()
    {
        _game = new Game(15, 15, 2);

        var grid = Instantiate(Grid, transform);
        var gridComponent = grid.GetComponent<GridComponent>();
  
        grid.transform.position = new Vector2(0, 0);
        gridComponent.Grid = _game.Grid;

        InvokeRepeating("Step", 0, 4);
    }

    void Update()
    {
    }
    
    void Step()
    { 
        foreach (var @base in _game.Bases)
            @base.Step();
    }
}
