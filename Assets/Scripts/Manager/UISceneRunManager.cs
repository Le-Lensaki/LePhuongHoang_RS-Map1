using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
public class UISceneRunManager : Singleton<UISceneRunManager>
{
    [SerializeField] protected GameObject sliderStamina;
    [SerializeField] protected GameObject sliderSpeed;
    [SerializeField] protected GameObject sliderRoad;
    [SerializeField] protected GameObject sliderGoal;
    [SerializeField] protected GameObject uIResult;
    [SerializeField] protected GameObject uILevel;
    [SerializeField] protected List<GameObject> listPosStart;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadGameObjectByName(ref sliderStamina, "SliderStamina");
        LoadGameObjectByName(ref sliderSpeed, "SliderSpeed");
        LoadGameObjectByName(ref sliderRoad, "SliderRoad");
        LoadGameObjectByName(ref sliderGoal, "SliderGoal");
        LoadGameObjectByName(ref uIResult, "UIResult");
        LoadGameObjectByName(ref uILevel, "UILevel");
    }

    public virtual void ChangeScreenPrepare()
    {
        sliderStamina.gameObject.SetActive(false);
        sliderSpeed.gameObject.SetActive(false);
        sliderRoad.gameObject.SetActive(false);
    }
    public virtual void ChangeScreenRun()
    {
        sliderStamina.gameObject.SetActive(true);
        sliderSpeed.gameObject.SetActive(true);
        sliderRoad.gameObject.SetActive(true);
    }
    public virtual void ChangeScreenStopGame()
    {
        ChangeScreenPrepare();
        sliderGoal.GetComponent<SliderGoal>().Generate();
        uIResult.gameObject.SetActive(true);
        uILevel.gameObject.SetActive(false);
        uIResult.transform.GetChild(1).GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), 1f, false).SetEase(Ease.InOutBack);
        Debug.Log("Stop");
    }
    public virtual void ChangeScreenRunToFinish()
    {
        sliderRoad.gameObject.SetActive(false);
        uILevel.gameObject.SetActive(false);
    }

    public virtual void SetLevel(int level)
    {
        uILevel.GetComponent<TMP_Text>().text = "Level " + level.ToString();
    }
    

}
