using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaMove : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horiz = Input.GetAxis("Horizontal") * speed;  //x
        float vert = Input.GetAxis("Vertical") * speed;  //z

        transform.position = new Vector3(transform.position.x + horiz, transform.position.y, transform.position.z + vert);

    }
}
