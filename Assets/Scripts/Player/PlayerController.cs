using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    [SerializeField] protected PlayerMovement movement;
    [SerializeField] protected PlayerStatus status;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadComponent(ref movement);
        LoadComponent(ref status);
    }

    public float GetSpeedPlayer()
    {
        return status.SpeedPlayer;
    }
    public float GetStaminaPlayer()
    {
        return status.StaminaPlayer;
    }

    public float UpSpeed()
    {
        return status.UpgradeSpeded();
    }

    public float UpStamina()
    {
        return status.UpgradeStamina();
    }

    public int NumberCatRescue()
    {
        return status.NumberCatRescue;
    }

    public void UpNubmerCatRescue()
    {
        status.UpdateNumberCatRescue();
        movement.SetUIMaxSpeed();
      
    }

    public void UseStaminaUpgradeSpeed()
    {
        float speedUp = status.UseStaminaUpgradeSpeed();

        if (speedUp == -1) return;

        movement.UpgradeSpeed(speedUp);
    }
    public void SaveStatus()
    {
        status.SaveStatus();
    }

    public int GetLevel()
    {
        return status.GetLevel();
    }

    public void UpLevel()
    {
        if (GetLevel() >= GameManager.Instance.numberLevelHave) return;
        status.UpLevel();
    }
    private void Update()
    {
        if(transform.position.z >=1400)
        {
            if (GameManager.Instance.gameStop) return;
            GameManager.Instance.StopGame();
        }
    }
}
