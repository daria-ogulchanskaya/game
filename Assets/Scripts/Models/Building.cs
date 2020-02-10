using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building 
{
    public int Level { get; internal set; }
    public bool Upgrading { get; internal set; }

    public abstract void LevelUp();
    public abstract void Upgrade();
}
