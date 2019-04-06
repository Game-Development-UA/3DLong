using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform man;
    public float speed;
    //public float rotateSpeed = 0.01F;
    public float dis;
    public float heightDis;


    float initalRotateY;
    // Start is called before the first frame update
    void Start()
    {
        initalRotateY = transform.rotation.y;
    }

    // Update is called once per frame
    void Update()
    {

        float height = man.position.y + heightDis;
        Vector3 target = new Vector3(man.position.x, height, man.position.z-dis);

        if (Input.GetAxis("Horizontal") != 0)
        {
            float rotateY = man.rotation.y - initalRotateY;
            transform.Rotate(0, rotateY, 0);
            initalRotateY = transform.rotation.y;
        }

        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
    }
}
