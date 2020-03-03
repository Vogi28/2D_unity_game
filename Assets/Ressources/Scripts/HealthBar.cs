using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    void update()
    {
        InvokeRepeating("setHealthColor", 1f, 0.3f);
    }

    // set max health
    public void setMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    // set health for slider
    public void setHealth(int health)
    {
        slider.value = health;
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Life"))
        {
            print(slider.value);
            slider.value += 1;
        }
    }

    private void setHealthColor()
    {
        if (slider.normalizedValue <= 0.3f)
        {
            fill.color = gradient.Evaluate(0.3f);
            fill.color = gradient.Evaluate(1f);
        }
    }
}
