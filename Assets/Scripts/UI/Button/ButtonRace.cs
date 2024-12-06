using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRace : ButtonBase
{
    protected override void OnClick()
    {
        LoadSceneManager.Instance.LoadMap("RunScene");
    }
}
