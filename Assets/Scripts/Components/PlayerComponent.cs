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
        Debug.Log("Goods" + Base.Resourses.Goods);
        Debug.Log("People" + Base.Resourses.People);
        Debug.Log("Credits" + Base.Resourses.Credits);
    }
}

