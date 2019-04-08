using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcMove : MonoBehaviour
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
        if (timer > 1)
        {
            dir_y = Random.Range(-1, 1f);   //取随机数，参数为浮点型，取得随机数就是浮点型
            timer = 0;  //当timer>4秒置空，重新生成随机数即改变运动方向
            transform.Rotate(new Vector3(0, dir_y, 0));
        }
        transform.position += transform.forward * speed * Time.deltaTime;
    }


}
