using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public abstract class SliderBase : LensakiMonoBehaviour
{
    [SerializeField] protected Slider slider;
    [SerializeField] public Slider Slider => slider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadComponent(ref slider);
        this.AddOnValueChanged();
    }

    protected void AddOnValueChanged()
    {
        this.slider.onValueChanged.AddListener(this.OnChanged);
    }

    protected abstract void OnChanged(float valueChanged);

    public virtual void SetValue(float value)
    {
        this.slider.value = value;
    }

}
