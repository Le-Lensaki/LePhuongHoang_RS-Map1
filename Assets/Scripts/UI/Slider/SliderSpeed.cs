using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SliderSpeed : SliderBase
{
    [SerializeField] protected TMP_Text maxSpeed;

    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadComponentByName(ref maxSpeed, "MaxSpeed");
    }
    #endregion

    public virtual void SetMaxSpeed(float maxSpeed)
    {
        this.maxSpeed.text = maxSpeed.ToString();
    }

    protected override void OnChanged(float valueChanged)
    {
        
    }
}
