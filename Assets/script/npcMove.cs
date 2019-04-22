using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcMove: MonoBehaviour
{

    public float speed = 5;
    private float timer = 0;
    private float dir_y = 0;

    private Animator action;
    // Use this for initialization
    void Start()
    {
        action = transform.gameObject.GetComponent<Animator>();
    }
   
    void Update()
    {
        timer += Time.deltaTime;
        if (speed > 10 && timer > 0.08)
        {
            speed = 4;
        }
        if (!action.GetBool("death") && !action.GetBool("alive"))
        {
            if (timer > 2)
            {
                dir_y = Random.Range(-100f, 100f);
                timer = 0;
                transform.Rotate(new Vector3(0, dir_y, 0));
            }
            transform.position += transform.forward * speed * Time.deltaTime;
        }


    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "tree")
        {
            speed = 80;
            timer = 0;
            dir_y = Random.Range(-180f, 180f);
            transform.Rotate(new Vector3(0, dir_y, 0));
            transform.position += transform.up * speed*2 * Time.deltaTime;
        }
    }


}
