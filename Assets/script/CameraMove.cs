using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public Transform target;//角色
    public Vector3 offset;//角色与摄像机位置偏差值
    private float _pointY;//玩家Y轴旋转角度
    public float damping = 1;//摄像机旋转阻尼

    // Use this for initialization
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
       
            _pointY = target.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0, _pointY, 0);
            transform.position = Vector3.Lerp(transform.position, target.position + (rotation * offset), 2*Time.deltaTime * damping);
            transform.LookAt(target.position);
        

      

    }

  



}
