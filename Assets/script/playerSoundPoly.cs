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

    private float timer = 0;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        // normal attack
        if (Input.GetKeyDown(KeyCode.J))
        {
            timer = 0;
            attack1();
        }

        // pray
        if (Input.GetKeyDown(KeyCode.K))
        {

        }
    }

    public virtual void attack1()
    {
        sounds.clip = flight;
        sounds.Play();

        if (timer > 0.4)
            sounds.Stop();
    }
}
