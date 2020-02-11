using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class PlayerComponent : MonoBehaviour
{
    public Base Base { get; set; }

    void OnMouseDown()
    {
        var resources = Base.Resourсes();

        Debug.Log("Goods" + resources.Goods);
        Debug.Log("People" + resources.People);
        Debug.Log("Credits" + resources.Credits);
    }
}

