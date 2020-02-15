using UnityEngine;

class ExpandComponent : MonoBehaviour
{
    public Base Base { get; set; }

    private void Start()
    {
        var player = FindObjectOfType<PlayerComponent>();
        Base = player.Base;
    }

    public void Expand()
    {
        var grid = FindObjectOfType<GridComponent>();
        grid.Grid.Expand(Base);
    }
}
