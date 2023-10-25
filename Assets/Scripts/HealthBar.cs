using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;

    //Setting max health of slider in unity editor
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    //Setting it to the player health
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
