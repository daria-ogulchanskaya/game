using System;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesDisplayComponent : MonoBehaviour
{
    public Text Resources;

    public Base Base { get; set; }

    private void Update()
    {
        Resources.text = $"Credits: {Base.Resources.Credits.ToString("#.#")}   " +
                    $"People: {Base.Resources.People.ToString("#.#")}   " +
                    $"Goods: {Base.Resources.Goods.ToString("#.#")}";
    }
}