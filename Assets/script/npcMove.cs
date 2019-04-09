using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcMove: MonoBehaviour
{

    public float speed = 4;
    private float timer = 0;
    private float dir_y = 0;

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            dir_y = Random.Range(-100f, 100f); 
            timer = 0;  
            transform.Rotate(new Vector3(0, dir_y, 0));
        }
        transform.position += transform.forward * speed * Time.deltaTime;

    }


}
