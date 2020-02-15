using UnityEngine;
using UnityEngine.UI;

public class UnitDisplayComponent : MonoBehaviour
{
    public Text Units;

    public Base Base { get; set; }

    private void Update()
    {
        Units.text = "Units: \n" +
            $"Attack: {Base.Army.AttackUnits}\n" +
            $"Defence: {Base.Army.DefenceUnits}\n" +
            $"Speed: {Base.Army.SpeedUnits}\n\n" +
            $"Unit limit: {Base.UnitLimit()}\n" +
            $"Population limit: {Base.PopulationLimit()}";
    }
}