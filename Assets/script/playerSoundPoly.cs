using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSoundPoly : MonoBehaviour
{
    public AudioClip flight;
    public AudioClip pickup;
    public AudioClip nopick;
    public AudioClip get;

    private AudioSource sounds;

    [HideInInspector]
    public int isFlower = 0;

    // Start is called before the first frame update
    public void Start()
    {
        sounds = transform.gameObject.GetComponent<AudioSource>();

    }

    private float timer = 0;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        // normal attack
        if (Input.GetKeyDown(KeyCode.J))
        {
            timer = 0;
            attack();
            if (timer > 0.4)
                sounds.Stop();
        }

        // pray
        if (Input.GetKeyDown(KeyCode.K))
        {

        }

        // pick up
        if (Input.GetKeyDown(KeyCode.S))
        {
            timer = 0;
            pick();
            if (timer > 0.4)
                sounds.Stop();
        }
    }

    public virtual void pick()
    {
        if (isFlower == 1)
            pickup1();
        else
            noPickUp();
    }

    public virtual void attack()
    {
        attack1();
    }

    public virtual void attack1()
    {
        sounds.clip = flight;
        sounds.Play();
    }

    public virtual void pickup1()
    {
        sounds.clip = pickup;
        sounds.Play();
    }

    public virtual void noPickUp()
    {
        sounds.clip = nopick;
        sounds.Play();
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponentInParent<Transform>().tag == "flower")
        {
            print("flower");
            isFlower = 1;
        }
        else
        {
            isFlower = 0;
        }
    }

}
