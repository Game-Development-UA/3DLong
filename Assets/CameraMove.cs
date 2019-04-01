using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform man;
    public float speed;
    //public float rotateSpeed = 0.01F;
    public float dis;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 target = new Vector3(man.position.x, transform.position.y, man.position.z-dis);

        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
    }
}
