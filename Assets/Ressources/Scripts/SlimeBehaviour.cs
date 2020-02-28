using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBehaviour : MonoBehaviour
{
    public float mvSpeed = 5f;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mv = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += mv * Time.deltaTime * mvSpeed;


        
    }
}
