using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaMove : MonoBehaviour
{
    public float speed = 0.5f;
    public float rotateSpeed = 3.0F;

    private Transform tran;
    private Animator m_animator;
    CharacterController controller;

    void Start()
    {
        tran = gameObject.GetComponent<Transform>();
        m_animator = gameObject.GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {

        float h = Input.GetAxis("Horizontal");//返回-1到1的实数值，可以来构造向量
        float v = Input.GetAxis("Vertical");//竖直方向

        transform.Rotate(0, h * rotateSpeed, 0);//AD键水平旋转

        Vector3 forward = transform.TransformDirection(Vector3.forward);

        float curSpeed = speed * v;

        //竖直方向，按下WS键，人物播放向前走动画，并前进。
        if (Mathf.Abs(v) > 0.1)//判断是否按下键WS
        {
            //第二种方法，用Translate
            if (Input.GetKey(KeyCode.UpArrow))
                tran.Translate(Vector3.forward * speed);
            else if (Input.GetKey(KeyCode.DownArrow))
                tran.Translate(Vector3.back * speed);

            m_animator.SetBool("run", true);//播放行走动画
        }
        else
        {
            m_animator.SetBool("run", false);
        }
    }
        
}
