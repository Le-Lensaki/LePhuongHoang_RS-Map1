using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : Singleton<LoadSceneManager>
{
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);
    }


    public void LoadMap(string mapToLoad)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(mapToLoad);
        loadOperation.allowSceneActivation = false;
        PlayerController.Instance.SaveStatus();
        loadOperation.allowSceneActivation = true;
    }


}
