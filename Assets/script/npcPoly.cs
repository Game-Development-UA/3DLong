using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcPoly : MonoBehaviour
{
    public AudioClip die;
    AudioSource sound;

    [HideInInspector]
    public GameObject player;

    Animator playerActions;

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
            StartCoroutine(deathAffect());
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
        transform.GetChild(0).gameObject.transform.position = transform.position;
        transform.GetChild(0).gameObject.SetActive(true);

        yield return null;
    }


    public virtual IEnumerator activeChildObject()
    {
        transform.GetChild(1).gameObject.transform.position = transform.position;
        transform.GetChild(1).gameObject.SetActive(true);
        yield return null;
    }

}
