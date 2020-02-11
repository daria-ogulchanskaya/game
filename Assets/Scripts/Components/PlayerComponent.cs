using UnityEngine;

class PlayerComponent : MonoBehaviour
{
    public Base Base { get; set; }

    void OnMouseDown()
    {
        var resources = Base.Resourсes();

        Debug.Log($"Goods: {resources.Goods}, " +
           $"People: {resources.People}, " +
           $"Credits: {resources.Credits}");
    }
}

