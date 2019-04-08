using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaMove : MonoBehaviour
{
    public float speed = 0.5f;
    public float rotateSpeed = 3.0F;

    private Transform tran;
    private Animator act;

    void Start()
    {
        tran = gameObject.GetComponent<Transform>();
        act = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        // rotation
        float h = Input.GetAxis("Horizontal");
        transform.Rotate(0, h * rotateSpeed, 0);

        // move
        if (Input.GetKey(KeyCode.W)) {
            tran.Translate(Vector3.forward * speed);
            act.SetBool("run", true);
        }

        else if (Input.GetKey(KeyCode.S))
        {
            tran.Translate(Vector3.back * speed);
            act.SetBool("run", true);
        }else
            act.SetBool("run", false);


        // jump
        if (Input.GetAxis("Jump") != 0)
        {
            tran.Translate(Vector3.up * speed*2);
        }

    }
        
}
