using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSoundPoly : MonoBehaviour
{
    public AudioClip flight;
    public AudioClip pickup;
    public AudioClip nopick;
    public AudioClip get;
    public AudioClip dan;

    private AudioSource sounds;
    private Animator act;

    [HideInInspector]
    public bool isFlower = false;
    [HideInInspector]
    public GameObject flower;

    [SerializeField]
    private int numOfFlower = 0;

    // Start is called before the first frame update
    public void Start()
    {
        sounds = transform.gameObject.GetComponent<AudioSource>();
        act = transform.gameObject.GetComponent<Animator>();
    }

    
    // Update is called once per frame
    void Update()
    {
        // normal attack
        if (Input.GetKeyDown(KeyCode.J))
        {
            attack();
        }

        // dance
        if (Input.GetKeyDown(KeyCode.K))
        {
            dance();
        }

        // pick up
        if (Input.GetKeyDown(KeyCode.S))
        {
            pick();
        }
        

    }

    public virtual void dance()
    {
        sounds.clip = dan;
        // play in chaMove.cs
    }

   
    public virtual void pick()
    {
        if (!isFlower)
            noPickUp();
        else
            StartCoroutine(pickup1());
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

    public virtual IEnumerator pickup1()
    {
        sounds.clip = pickup;
        sounds.Play();

        yield return new WaitForSeconds(1);
        numOfFlower += 1;
        isFlower = false;

        yield return new WaitForSeconds(1);
        Destroy(flower);

    }

    public virtual void noPickUp()
    {
        sounds.clip = nopick;
        sounds.Play();
    }


}
