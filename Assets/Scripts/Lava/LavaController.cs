using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaController : Singleton<LavaController>
{
    [SerializeField] protected LavaMovement movement;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadComponent(ref movement);
    }

    public void StartLavaMove()
    {
        movement.StartLavaMove();
    }
    public void StopLava()
    {
        movement.StopLava();
    }
}
