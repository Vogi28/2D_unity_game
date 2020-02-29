using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManaHandler : MonoBehaviour
{
    public Image lifeBar;
    public Image manaBar;

    public float myLife;
    public float myMana;

    private float currentLife;
    private float currentMana;
    private float calculLife;

    // Start is called before the first frame update
    void Start()
    {
        currentLife = myLife;
        currentMana = myMana;
    }

    // Update is called once per frame
    void Update()
    {
        calculLife = currentLife / myLife;
        lifeBar.fillAmount = Mathf.MoveTowards(lifeBar.fillAmount, calculLife, Time.deltaTime);
    }
}
