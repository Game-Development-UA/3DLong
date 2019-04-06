using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaMove : MonoBehaviour
{
    public float speed = 0.5f;
    public float rotateSpeed = 3.0F;

    private Transform tran;

    void Start()
    {
        tran = gameObject.GetComponent<Transform>();
    }

    void Update()
    {

        float h = Input.GetAxis("Horizontal");

        transform.Rotate(0, h * rotateSpeed, 0);

        if (Input.GetKey(KeyCode.UpArrow))
            tran.Translate(Vector3.forward * speed);
        else if (Input.GetKey(KeyCode.DownArrow))
            tran.Translate(Vector3.back * speed);
           
        
 
    }
        
}
