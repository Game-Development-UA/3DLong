using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chaMove : MonoBehaviour
{
    public float speed = 0.5f;
    public float rotateSpeed = 3.0F;

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
        if (!act.GetBool("attack"))
        {
            // move
            if (Input.GetKey(KeyCode.W))
            {
                tran.Translate(Vector3.forward * speed);
                act.SetBool("run", true);
            }
            else
                act.SetBool("run", false);
        }
        // rotation
        float h = Input.GetAxis("Horizontal");
        transform.Rotate(0, h * rotateSpeed, 0);


        // jump
        if (Input.GetAxis("Jump") != 0)
        {
            tran.Translate(Vector3.up * speed*2);
        }

        timer += Time.deltaTime;
        // attack
        if (Input.GetKey(KeyCode.Q))
        {
            timer = 0;
            act.SetBool("attack", true);
        }
        else if (timer > 0.2)
        {

            act.SetBool("attack", false);
        }

        
    }

    public string sceneName; 
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "npc" && act.GetBool("attack"))
        {
            print("kill!!");
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "trans") {
            SceneManager.LoadScene(sceneName);
        }

    }


}
