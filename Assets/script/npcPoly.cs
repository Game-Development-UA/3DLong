using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcPoly : MonoBehaviour
{
    public AudioClip die;


    public virtual void Start()
    {

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

    }

}
