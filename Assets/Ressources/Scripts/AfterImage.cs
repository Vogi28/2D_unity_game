using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterImage : MonoBehaviour
{
    private float activeTime = 0.1f;
    private float timeActivated;
    private float alpha;
    private float alphaSet = 0.8f;
    private float alphaMultiplier = 0.85f;


    private Transform player;
    
    private SpriteRenderer SR;
    private SpriteRenderer playerSR;
    
    private Color color;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // decrease alpha
        alpha *= alphaMultiplier;

        // create new color
        color = new Color(1f, 1f, 1f, alpha);
        // set this color to our sprite
        SR.color = color;

        // check if active image has been activated for long enough
        if (Time.time >= (timeActivated + activeTime))
        {
            AfterImagePool.Instance.AddToPool(gameObject);
        }
    }

    private void OnEnable()
    {
        // get spriteRenderer
        SR = GetComponent<SpriteRenderer>();
        // get reference of our player
        player = GameObject.FindGameObjectWithTag("Player").transform;
        // get spriteRenderer of our player
        playerSR = player.GetComponent<SpriteRenderer>();

        // set alpha
        alpha = alphaSet;
        // get the correct sprite
        SR.sprite = playerSR.sprite;
        // set position
        transform.position = player.position;
        // set rotation
        transform.rotation = player.rotation;
        // set timeActivated
        timeActivated = Time.time;
    }
}
