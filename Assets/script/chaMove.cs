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
            act.SetBool("dance", false);
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
        if (Input.GetKey(KeyCode.J))
        {
            timer = 0;
            act.SetBool("attack", true);
        }
        else if (timer > 1 && act.GetBool("attack"))
        {
            Debug.Log("turn off attack");
            act.SetBool("attack", false);
        }

        // dance
        if (Input.GetKey(KeyCode.K))
        {
            timer = 0;
            act.SetBool("dance", true);
        }
        else if (timer > 6 && act.GetBool("dance"))
        {
            Debug.Log("turn off dance");
            act.SetBool("dance", false);
        }

        // pick up
        if (Input.GetKey(KeyCode.S))
        {


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
