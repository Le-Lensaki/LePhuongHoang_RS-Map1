using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SliderGoal : SliderBase
{
    [SerializeField] protected TMP_Text textValueRescue;
    [SerializeField] protected TMP_Text textLevelMap;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadComponentByName(ref textValueRescue, "ValueRescue");
        LoadComponentByName(ref textLevelMap, "LevelMap");
    }
    public void Generate()
    {
        SetValue(Mathf.Round(PlayerController.Instance.transform.position.z));
        textValueRescue.text = PlayerController.Instance.NumberCatRescue().ToString()+"/6";
        textLevelMap.text = "LEVEL " + PlayerController.Instance.GetLevel().ToString();
    }

    protected override void OnChanged(float valueChanged)
    {
        
    }
}
