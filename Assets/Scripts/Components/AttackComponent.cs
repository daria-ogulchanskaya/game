using System;
using UnityEngine;
using UnityEngine.UI;

class AttackComponent : MonoBehaviour
{
    public InputField AttackUnits;
    public InputField DefenceUnits;
    public InputField SpeedUnits;

    public Base Base { get; set; }
    public Base EnemyBase { get; set; }

    public Game Game { get; set; }

    public GameObject Menu;

    private void Start()
    {
        var player = FindObjectOfType<PlayerComponent>();
        Base = player.Base;
    }

    public void Attack()
    {
        var army = new Army();

        army.Add(Unit.Type.Attack, int.Parse(AttackUnits.text));
        army.Add(Unit.Type.Defence, int.Parse(DefenceUnits.text));
        army.Add(Unit.Type.Speed, int.Parse(SpeedUnits.text));

        if (!Base.Army.Has(army))
            throw new Exception("You do not have enough units.");

        Base.Army.Remove(army);

        if (!EnemyBase.CanDefendAgainst(army))
        {
            Game.Grid.Remove(EnemyBase);
            Base.Army.Add(army);
            Base.Resources.Add(Settings.Battle.VictoryReward);
        }
    }
}
