using UnityEngine;
using UnityEngine.UI;

class SellComponent : MonoBehaviour
{
    public InputField SellCount;

    public Base Base { get; set; }

    private void Start()
    {
        var player = FindObjectOfType<PlayerComponent>();
        Base = player.Base;
    }

    public void Sell()
    {
        Base.Sell(int.Parse(SellCount.text));
        SellCount.text = "";
    }
}
