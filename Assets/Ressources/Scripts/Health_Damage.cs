using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Damage : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    public HealthBar healthBar;
    public int maxMana = 10;
    public int currentMana;
    public ManaBar manaBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);

        currentMana = maxMana;
        manaBar.SetMaxMana(maxMana);

        InvokeRepeating("FillMana", 0.1f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
            takeDamage(1);

        if (Input.GetKeyDown(KeyCode.H))
            ManaUse(1);
    }

    // damage function
    public void takeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.setHealth(currentHealth);
    }

    // mana use
    public void ManaUse(int mana)
    {
        currentMana -= mana;

        manaBar.SetMana(currentMana);
    }

    public void FillMana()
    {
        if (currentMana < 10)
        {
            currentMana += 1;

            manaBar.SetMana(currentMana);
        }
    }
}
