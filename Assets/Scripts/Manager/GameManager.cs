using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] public bool canTouch;
    [SerializeField] public bool enableJoyStick;
    [SerializeField] public bool gameStart;
    [SerializeField] public bool gameStop;
    [SerializeField] public bool gamePause;
    [SerializeField] public bool gameRunToFinish;
    [SerializeField] protected GameObject camFollowPlayerFinish;

    [SerializeField] protected List<LevelSO> levelGames;
    public int numberLevelHave => levelGames.Count;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadListLevel();
        LoadGameObjectByName(ref camFollowPlayerFinish, "CamFollowPlayerFinish");
    }
    protected virtual void LoadListLevel()
    {
        if (this.levelGames.Count > 0) return;
        string resPath = "DataLevel/" + "";
        LevelSO[] levels = Resources.LoadAll<LevelSO>(resPath);
        foreach (var item in levels)
        {
            levelGames.Add(item);
        }
        Debug.LogWarning(transform.name + ": LoadLevel " + resPath, gameObject);
    }


    public void LoadLevel()
    {
        int levelPlayer = PlayerController.Instance.GetLevel();
        int levelPlay = (levelPlayer >= levelGames.Count) ? levelGames.Count : levelPlayer;

        LevelSO level = levelGames[levelPlay-1];

        if(level !=null)
        {
            CatSpawner spawnerCat = SpawnerManager.Instance.GetSpawner<CatSpawner>();
            CarSpawner spawnerCar = SpawnerManager.Instance.GetSpawner<CarSpawner>();
            foreach (var item in level.GetListStatusCatSpawn)
            {
                spawnerCat.SpawnCat(item.nameCat, item.posCatSpawn,item.catIsMove);
            }
            foreach (var item in level.GetListStatusCarSpawn)
            {
                spawnerCar.SpawnCar(item.nameCar, item.posCarSpawn);
            }
        }
        UISceneRunManager.Instance.SetLevel(levelPlay);
    }    


    public void StartGame()
    {
        gameStart = true;
        enableJoyStick = true;
        canTouch = true;
        LavaController.Instance.StartLavaMove();
        
    }
    public void StopGame()
    {
        gameStop = true;
        gameRunToFinish = false;
        gameStart =false;
        enableJoyStick = false;
        canTouch = false;
        InputManager.Instance.StopInput();
        UISceneRunManager.Instance.ChangeScreenStopGame();
        LavaController.Instance.StopLava();
        CheckWin();
    }

    protected bool CheckWin()
    {
        if (PlayerController.Instance.transform.position.z < 1400) return false;
        
        if(PlayerController.Instance.NumberCatRescue() < 6) return false;

        PlayerController.Instance.UpLevel();
        return true;
        
    }

    public void RunToFinish()
    {
        if (PlayerController.Instance.NumberCatRescue() == 6)
        {
            UISceneRunManager.Instance.ChangeScreenRunToFinish();
            gameRunToFinish = true;
            enableJoyStick = false;
            canTouch = true;
            camFollowPlayerFinish.SetActive(true);
            PlayerController.Instance.transform.rotation = Quaternion.identity;

            Vector3 posPlayer = PlayerController.Instance.transform.position;
            posPlayer.x = 50f;
            PlayerController.Instance.transform.position = posPlayer;
            InputManager.Instance.StopInput();
            InputManager.Instance.RunToFinish();
        }  
    }


    public void CanTouch()
    {
        canTouch = true;
    }
    public void NoTouch()
    {
        canTouch = false;
    }

    
    
    
}
