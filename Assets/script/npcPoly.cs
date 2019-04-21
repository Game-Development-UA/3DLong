using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcPoly : MonoBehaviour
{
    public AudioClip die;
    private AudioSource sound;

    public virtual void Start()
    {
        sound = transform.gameObject.GetComponent<AudioSource>();
    }

    public virtual void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.name == "player")
        {
            Animator playerActions = col.gameObject.GetComponent<Animator>();
            if (playerActions.GetBool("attack"))
                deathAffect();
        }
    }

    public virtual void deathAffect()
    {
        Animator npcAction = transform.gameObject.GetComponent<Animator>();
        npcAction.SetBool("death", true);
        sound.clip = die;
        sound.Play();

        transform.GetChild(0).gameObject.SetActive(true);
        active();
    }

    public virtual void active()
    {

    }

}
