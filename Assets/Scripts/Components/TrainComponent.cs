using UnityEngine;
using UnityEngine.UI;

public class TrainComponent : MonoBehaviour
{
    public InputField AttackUnits;
    public InputField DefenceUnits;
    public InputField SpeedUnits;

    public Base Base { get; set; }

    private void Start()
    {
        var player = FindObjectOfType<PlayerComponent>();
        Base = player.Base;
    }

    public void Train()
    {
        var army = new Army();

        army.Add(Unit.Type.Attack, int.Parse(AttackUnits.text));
        army.Add(Unit.Type.Defence, int.Parse(DefenceUnits.text));
        army.Add(Unit.Type.Speed, int.Parse(SpeedUnits.text));

        Base.StartTrain(army);
    }
}
