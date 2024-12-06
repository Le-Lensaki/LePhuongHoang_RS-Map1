using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    [SerializeField] protected GameObject camFollowChange;
    [SerializeField] protected GameObject camFollowPlayer;
    [SerializeField] protected GameObject camFollowLava;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadGameObjectByName(ref camFollowChange, "CamFollowChange");
        LoadGameObjectByName(ref camFollowPlayer, "CamFollowPlayer");
        LoadGameObjectByName(ref camFollowLava, "CamFollowLava");
    }
}
