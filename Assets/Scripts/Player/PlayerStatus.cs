using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : LensakiMonoBehaviour
{
    [SerializeField] protected PlayerStatusSO playerStatusSO;
    public float SpeedPlayer => playerStatusSO.speed;
    public float StaminaPlayer => playerStatusSO.maxStamina;

    [SerializeField] protected float currentStamina;

    [SerializeField] protected int numberCatRescue;
    public int NumberCatRescue => numberCatRescue;
    

    protected int countLevelUpStamina;
    [SerializeField] protected SliderStamina sliderStamina;
    private float timer;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadComponentByName(ref sliderStamina, "SliderStamina");
    }
    protected override void Start()
    {
        base.Start();
        Generate();
        SetUIMaxStamina();
    }

    protected void Generate()
    {
        playerStatusSO.Load();
        numberCatRescue = 0;
        countLevelUpStamina = 0;
        if (sliderStamina == null) return;
        GameManager.Instance.LoadLevel();
        currentStamina = playerStatusSO.maxStamina;
        sliderStamina.Slider.maxValue = playerStatusSO.maxStamina;
        sliderStamina.SetValue(currentStamina);
    }

    public void SaveStatus()
    {
        playerStatusSO.Save();
    }
    protected void SetUIMaxStamina()
    {
        if (sliderStamina == null) return;
        this.sliderStamina.SetTextMaxStamina(playerStatusSO.maxStamina);
    }

    public float UpgradeSpeded()
    {
        float speedUp = playerStatusSO.speed + 0.1f;

        playerStatusSO.speed = Mathf.Round(speedUp*10)/10;
        return playerStatusSO.speed;
    }

    public float UpgradeStamina()
    {
        playerStatusSO.maxStamina += playerStatusSO.staminaLevelUp;

        if (countLevelUpStamina == 2)
        {
            countLevelUpStamina = 0;
            playerStatusSO.staminaLevelUp++;
            return playerStatusSO.maxStamina;
        }
        countLevelUpStamina++;
        return playerStatusSO.maxStamina;
    }

    public int UpdateNumberCatRescue()
    {
        numberCatRescue++;
        return numberCatRescue;
    }

    public float UseStaminaUpgradeSpeed()
    {
        if (currentStamina <= 0) return -1;

        timer = 0f;
        float staminaCost = playerStatusSO.maxStamina * 10f / 100f;

        currentStamina = Mathf.Clamp(currentStamina - staminaCost, 0, playerStatusSO.maxStamina);

        return Mathf.Round(playerStatusSO.maxStamina * 10 / 100)/10;
    }

    private void Update()
    {
        ReStamina();
    }

    protected void ReStamina()
    {
        if (sliderStamina == null) return;
        timer += Time.deltaTime;
        if (timer >= 2f)
        {
            RegenerateStamina();
            timer = 0f;
        }

        sliderStamina.Slider.value = Mathf.Lerp(sliderStamina.Slider.value, currentStamina, Time.deltaTime * 10f);
    }

    protected void RegenerateStamina()
    {
        if (currentStamina >= playerStatusSO.maxStamina) return;

        currentStamina += playerStatusSO.maxStamina * 10 / 100;

        sliderStamina.SetValue(Mathf.Lerp(sliderStamina.Slider.value, currentStamina, Time.deltaTime * 10f));
    }


    public void UpLevel()
    {
        playerStatusSO.levelMap++;
    }

    public int GetLevel()
    {
        return playerStatusSO.levelMap;
    }
}
