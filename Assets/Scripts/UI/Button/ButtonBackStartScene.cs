using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBackStartScene : ButtonBase
{
    protected override void OnClick()
    {
        LoadSceneManager.Instance.LoadMap("StartScene");
    }
}
