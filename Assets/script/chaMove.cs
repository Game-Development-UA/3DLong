using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chaMove : MonoBehaviour
{
    public float speed = 10f;
    public float rotateSpeed = 2F;

    private Transform tran;
    private Animator act;

    void Start()
    {
        tran = gameObject.GetComponent<Transform>();
        act = gameObject.GetComponent<Animator>();
    }

    private float timer = 0;
    void Update()
    {
        timer += Time.deltaTime;

        // move
        if (Input.GetKey(KeyCode.W))
        {
            tran.Translate(Vector3.forward * speed * Time.deltaTime);
            act.SetBool("run", true);
        }
        else
            act.SetBool("run", false);
        
        // rotation
        float h = Input.GetAxis("Horizontal");
        transform.Rotate(0, h * rotateSpeed, 0);


        // jump
        if (Input.GetAxis("Jump") != 0)
        {
            tran.Translate(Vector3.up * speed*2*Time.deltaTime);
        }

        // attack
        if (Input.GetKey(KeyCode.Q))
        {
            timer = 0;
            act.SetBool("attack", true);
        }
        else if (timer > 0.4)
        {
            act.SetBool("attack", false);
        }

        
    }

    public string sceneName; 
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "trans") {
            SceneManager.LoadScene(sceneName);
        }

    }


}
