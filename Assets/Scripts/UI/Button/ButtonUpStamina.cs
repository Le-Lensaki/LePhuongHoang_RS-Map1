using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonUpStamina : ButtonBase
{
    [SerializeField] protected TMP_Text textStamina;

    protected override void Start()
    {
        base.Start();
        textStamina.text = PlayerController.Instance.GetStaminaPlayer().ToString();
    }
    protected override void OnClick()
    {
        textStamina.text = Mathf.Round(PlayerController.Instance.UpStamina()).ToString();
    }
}
