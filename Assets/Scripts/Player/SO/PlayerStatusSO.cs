using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Player", menuName = "SO/StatusPlayer")]
public class PlayerStatusSO : ScriptableObject
{
    public float speed;
    public float maxStamina;
    public int staminaLevelUp;
    public int levelMap;

    public void Save()
    {
        PlayerPrefs.SetFloat("speed", speed);
        PlayerPrefs.SetFloat("maxStamina", maxStamina);
        PlayerPrefs.SetInt("staminaLevelUp", staminaLevelUp);
        PlayerPrefs.SetInt("levelMap", levelMap);
        PlayerPrefs.Save();
    }
    public void Load()
    {
        this.speed = PlayerPrefs.GetFloat("speed", 1f);
        this.maxStamina = PlayerPrefs.GetFloat("maxStamina", 60f);
        this.staminaLevelUp = PlayerPrefs.GetInt("staminaLevelUp", 1);
        this.levelMap = PlayerPrefs.GetInt("levelMap", 1);
    }    
}
