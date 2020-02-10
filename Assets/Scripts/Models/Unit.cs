using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public enum Type
    {
        Attack,
        Defence,
        Speed
    }

    public int Speed { get; private set; }
    public double Attack { get; private set; }
    public double Defence { get; private set; }
}
