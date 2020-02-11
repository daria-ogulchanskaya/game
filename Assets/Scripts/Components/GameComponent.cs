using UnityEngine;

public class GameComponent : MonoBehaviour
{
    public GameObject Grid;

    public int GameStepDuration;
    public int Width;
    public int Height;
    public int Enemies;

    private Game _game;

    private void Start()
    {
        _game = new Game(Width, Height, Enemies);

        var grid = Instantiate(Grid, transform);
        var gridComponent = grid.GetComponent<GridComponent>();
  
        gridComponent.Grid = _game.Grid;

        InvokeRepeating(nameof(Step), GameStepDuration, GameStepDuration);
    }
    
    private void Step()
    { 
        foreach (var @base in _game.Bases)
            @base.Step();
    }
}
