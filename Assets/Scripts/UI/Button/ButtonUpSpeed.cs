using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonUpSpeed : ButtonBase
{
    [SerializeField] protected TMP_Text textSpeed;
    protected override void Start()
    {
        base.Start();
        textSpeed.text = PlayerController.Instance.GetSpeedPlayer().ToString();
    }
    protected override void OnClick()
    {
        textSpeed.text = (Mathf.Round(PlayerController.Instance.UpSpeed()*10f)/10f).ToString();
    }
}
