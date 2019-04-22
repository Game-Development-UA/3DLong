using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSoundPoly : MonoBehaviour
{
    public AudioClip flight;
    public AudioClip pickup;

    private AudioSource sounds;

    // Start is called before the first frame update
    public void Start()
    {
        sounds = transform.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // normal attack
        if (Input.GetKey(KeyCode.J))
        {
            attack1();
        }
    }

    public virtual void attack1()
    {
        sounds.clip = flight;
        sounds.Play();
    }
}
