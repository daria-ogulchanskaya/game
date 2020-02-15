using UnityEngine;
using UnityEngine.UI;

class BuyComponent : MonoBehaviour
{
    public InputField BuyCount;

    public Base Base { get; set; }

    private void Start()
    {
        var player = FindObjectOfType<PlayerComponent>();
        Base = player.Base;
    }

    public void Buy()
    {
        Base.Buy(int.Parse(BuyCount.text));
        BuyCount.text = "";
    }
}
