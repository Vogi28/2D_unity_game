using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SetManaRefill", 0.1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // set max mana
    public void SetMaxMana(int mana)
    {
        slider.maxValue = mana;
        slider.value = mana;
    }

    // set current mana
    public void SetMana(int mana)
    {
        slider.value = mana;
    }

    // set mana refill
    public void SetManaRefill()
    {
        if (slider.value < 1f)
            slider.value += 0.1f;
    }
}
