using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SliderStamina : SliderBase
{
    [SerializeField] protected TMP_Text maxStamina;

    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadComponentByName(ref maxStamina, "MaxStamina");
    }
    #endregion

    public virtual void SetTextMaxStamina(float maxStamina)
    {
        this.maxStamina.text = maxStamina.ToString();
    }

    protected override void OnChanged(float valueChanged)
    {

    }
}
