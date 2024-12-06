using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonBase : LensakiMonoBehaviour
{
    [SerializeField] protected Button button;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadComponent(ref button);
    }

    protected override void Start()
    {
        base.Start();
        AddOnClickEvent();
    }


    protected void AddOnClickEvent()
    {
        this.button.onClick.AddListener(this.OnClick);
    }

    protected abstract void OnClick();


}
