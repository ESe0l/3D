using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public UICondition uiCondition;

    Condition health { get { return uiCondition.health; } }
    Condition stamina { get { return uiCondition.stamina; } }

    // Update is called once per frame
    void Update()
    {
        PlayerController player = FindObjectOfType<PlayerController>();

        if (player != null)
        {
            // Decrease stamina when running
            if (player.isRunning && stamina.curValue > 0)
            {
                stamina.Add(-stamina.passiveValue * Time.deltaTime);
            }
            else if (!player.isRunning && stamina.curValue < stamina.maxValue)
            {
                stamina.Add(stamina.passiveValue * Time.deltaTime);
            }
            
            if (stamina.curValue < 0)
            {
                stamina.curValue = 0;
            }
    
            if (health.curValue == 0f)
            {
                Die();
            }
        }
    }

    public void Heal(float amount)
    {
        health.Add(amount);
    }

    public void Die()
    {
        
    }
}
