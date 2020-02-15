using Assets.Scripts.Models.Behaviours;
using UnityEngine;

public class EnemyComponent : MonoBehaviour
{
    public Base Base { get; set; }
    public Game Game { get; set; }
    public Assets.Scripts.Models.Behaviours.Behaviour Behaviour { get; set; }
    public GameObject Menu;

    private void Start()
    {
        var game = FindObjectOfType<GameComponent>();
        Game = game.Game;

        var objects = UnityEngine.Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[];

        foreach (var @object in objects)
            if (@object.name == "AttackMenu")
                Menu = @object;
    }

    private void OnMouseDown()
    {
        Menu.SetActive(true);

        var attackComponent = Menu.GetComponentInChildren<AttackComponent>();
        attackComponent.EnemyBase = Base;
        attackComponent.Game = Game;
    }

    public void Step() =>
        Behaviour.Step(Base, Game);
}
