using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMove : MonoBehaviour
{

    public Transform target;
    public float damping = 3;

    [HideInInspector]
    public Vector3 offset;
    private float _pointY;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
            _pointY = target.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0, _pointY, 0);
            transform.position = Vector3.Lerp(transform.position, target.position + (rotation * offset), 2*Time.deltaTime * damping);
            transform.LookAt(target.position);

    }
    

  


}
