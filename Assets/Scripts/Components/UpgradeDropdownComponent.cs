using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeDropdownComponent : MonoBehaviour
{
    public Base Base { get; set; }

    private void Start()
    {
        var player = FindObjectOfType<PlayerComponent>();

        Base = player.Base;

        DisplayBuildings();
    }

    public void DisplayBuildings()
    {
        var dropdown = FindObjectOfType<Dropdown>();
        var options = new List<Dropdown.OptionData>();

        foreach (var building in Base.Buildings)
        {
            var option = new Dropdown.OptionData
            {
                text = building.ToString()
            };

            options.Add(option);
        }

        dropdown.AddOptions(options);
    }
}
