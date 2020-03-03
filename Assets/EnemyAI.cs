using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 2.5f;
    private Rigidbody2D rb;
    public Transform player;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void FixedUpdate()
    {
        Vector3 direction = player.position - transform.position;
        move(direction);
        flip(direction);
        //print(direction);
    }

    private void move(Vector3 scale)
    {
        if (scale.x > -5f && scale.x < 5f)
        {
            Vector3 mv = new Vector3(scale.x, 0f, 0f);
            transform.position += mv * Time.deltaTime * speed;
        }
    }

    private void flip(Vector3 direction)
    {
        Vector3 _scale = transform.localScale;

        if (direction.x < 0f)
            _scale.x *= -1;
        else
            _scale.x *= 1;

        transform.localScale = _scale;
    }

    /*private Vector3 GetRoamingPosition()
    {
       return startingPosition + GetRandomDir() * Random.Range(10f, 0f);
    }

    private Vector3 GetRandomDir()
    {
        return new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normaliwed;
    }*/
}
