using UnityEngine;

public class GameComponent : MonoBehaviour
{
    public GameObject Grid;

    public int GameStepDuration;
    public int Width;
    public int Height;
    public int Enemies;

    public Game Game { get; private set; }

    private void Start()
    {
        Game = new Game(Width, Height, Enemies);

        var grid = Instantiate(Grid, transform);
        var gridComponent = grid.GetComponent<GridComponent>();
  
        gridComponent.Grid = Game.Grid;
        gridComponent.Game = Game;

        InvokeRepeating(nameof(Step), GameStepDuration, GameStepDuration);
    }
    
    private void Step()
    { 
        foreach (var @base in Game.Bases)
            @base.Step();

        foreach (var enemy in EnemyComponents())
            enemy.Step();
    }

    private EnemyComponent[] EnemyComponents() =>
        FindObjectsOfType<EnemyComponent>();
}
