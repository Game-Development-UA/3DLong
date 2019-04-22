using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcPoly : MonoBehaviour
{
    public AudioClip die;
    AudioSource sound;

    [HideInInspector]
    public GameObject player;

    [HideInInspector]
    public Animator playerActions;

    public virtual void Start()
    {
        sound = transform.gameObject.GetComponent<AudioSource>();
    }

    public virtual void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "player")
        {
            player = col.gameObject;
            playerActions = col.gameObject.GetComponent<Animator>();
            actions();
        }
    }

    public virtual void actions()
    {
        if (playerActions.GetBool("attack"))
        {
            StartCoroutine(deathAffect());
        }

    }

    public virtual IEnumerator deathAffect()
    {
        StartCoroutine(playDeathAnime());
        yield return new WaitForSeconds(2);
        StartCoroutine(activeChildNpc());
    }

    public virtual IEnumerator deathAffect2()
    {
        StartCoroutine(playDeathAnime());
        yield return new WaitForSeconds(2);
        StartCoroutine(activeChildObject());
    }

    public virtual IEnumerator playDeathAnime()
    {
        Animator npcAction = transform.gameObject.GetComponent<Animator>();
        npcAction.SetBool("death", true);

        sound.clip = die;
        sound.Play();

        yield return null;
    }


    public virtual IEnumerator activeChildNpc()
    {
        GameObject child = transform.GetChild(0).gameObject;
        child.transform.position = transform.position;
        child.SetActive(true);

        // turn off the parent collider
        transform.GetComponent<CapsuleCollider>().enabled = !transform.GetComponent<CapsuleCollider>().enabled;

        // play alive anime
        Animator childAnime = child.GetComponent<Animator>();
        childAnime.SetBool("alive", true);


        yield return new WaitForSeconds(1.5f);

        childAnime.SetBool("alive", false);
        
    }


    public virtual IEnumerator activeChildObject()
    {
        transform.GetChild(1).gameObject.transform.position = transform.position;
        transform.GetChild(1).gameObject.SetActive(true);
        yield return null;
    }

}
