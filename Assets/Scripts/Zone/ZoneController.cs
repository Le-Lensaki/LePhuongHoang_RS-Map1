using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneController : LensakiMonoBehaviour
{
    [SerializeField] protected Renderer rendererZone;
    [SerializeField] protected Color colorDefault;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadComponent(ref rendererZone);
        colorDefault = rendererZone.material.color;
    }
    protected override void Start()
    {
        HideZone();
    }
    public void ShowZone()
    {
        rendererZone.material.color = colorDefault;
    }

    public void HideZone()
    {
        Color newCorlor = colorDefault;
        newCorlor.a = 0f;
        rendererZone.material.color = newCorlor;
    }
}
