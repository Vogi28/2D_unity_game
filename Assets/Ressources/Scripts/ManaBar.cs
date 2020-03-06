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

}
