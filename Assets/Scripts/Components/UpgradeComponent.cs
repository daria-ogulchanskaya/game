using UnityEngine;
using UnityEngine.UI;

public class UpgradeComponent : MonoBehaviour
{
    public Dropdown Buildings;

    public Base Base { get; set; }

    private void Start()
    {
        var player = FindObjectOfType<PlayerComponent>();
        Base = player.Base;
    }
    
    public void Upgrade()
    {
        // The indices of the elements in a dropdown start from 1.
        var index = Buildings.value - 1;
        var building = Base.Buildings[index];

        Base.StartUpgrade(building);
    }
}
