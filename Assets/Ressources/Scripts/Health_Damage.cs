using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Damage : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    public int maxMana = 10;
    public int currentMana;

    public HealthBar healthBar;
    public ManaBar manaBar;
    public GameObject deathEffect;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);

        currentMana = maxMana;
        manaBar.SetMaxMana(maxMana);

        InvokeRepeating("FillMana", 0.1f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // damage function
    public void takeDamage(int damage)
    {
        if((currentHealth -= damage) <= 0)
        {
            //FindObjectOfType<Game_manager>().Endgame();
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
        Debug.Log(gameObject);
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

    // check collision in
    private void OnTriggerEnter2D(Collider2D col)
    {
        // compare object by tag
        if (col.gameObject.CompareTag("Enemy"))
        {
            takeDamage(1);
<<<<<<< HEAD
            rb.velocity = new Vector2(-5f, 0);
            if(currentHealth <= 0)
            {
                FindObjectOfType<GameManager>().EndGame();
            }
=======

>>>>>>> f700f204cc117fa6c4864713e4bcce33b9ba0a8a
        }
    }


}
