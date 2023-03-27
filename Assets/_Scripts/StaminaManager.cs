using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaManager : MonoBehaviour
{
    [SerializeField] private Slider staminaBar;
    
    void Start()
    {
        staminaBar.maxValue = PlayerInfo.maxStamina;
    }
    
    void Update()
    {
        if (LevelManager.isGameOver) return;
        PlayerInfo.maxStamina = staminaBar.maxValue;
    }
}
