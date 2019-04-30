using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerSoundPoly : MonoBehaviour
{
    public AudioClip flight;
    public AudioClip pickup;
    public AudioClip nopick;
    public AudioClip get;
    public AudioClip dan;

    [SerializeField]
    private int numOfStone = 0;
    public int goal;

    private AudioSource sounds;
    private Animator act;

    [HideInInspector]
    public bool isFlower = false;
    [HideInInspector]
    public GameObject flower;

    [HideInInspector]
    public bool isMile = false;
    [HideInInspector]
    public GameObject mile;

    [HideInInspector]
    public int numOfFlower = 0;
    [HideInInspector]
    public int errorPick = 0;
    [HideInInspector]
    public int errorSet = 0;

    public string sceneName;

    // Start is called before the first frame update
    public void Start()
    {
        sounds = transform.gameObject.GetComponent<AudioSource>();
        act = transform.gameObject.GetComponent<Animator>();
    }

    
    // Update is called once per frame
    void Update()
    {
        if (numOfStone == goal)
        {
            SceneManager.LoadScene(sceneName);
        }
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
            StartCoroutine(pick());
        }

        // set flower
        if (Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine(set());
        }


    }

    public virtual IEnumerator set()
    {
        if (isMile == false || numOfFlower < 1)
        {
            noPickUp();
            errorSet = 1;
            yield return new WaitForSeconds(3);
            errorSet = 0;
        }
        else
        {
            GameObject active = mile.transform.GetChild(0).gameObject;
            if (!active.activeSelf)
            {
                sounds.clip = get;
                sounds.Play();

                active.SetActive(true);

                yield return new WaitForSeconds(1);

                numOfStone += 1;
                numOfFlower -= 1;
                isMile = false;
            }
            else
            {
                noPickUp();
                errorSet = 1;
                yield return new WaitForSeconds(3);
                errorSet = 0;
            }
        }
    }

    public virtual void dance()
    {
        sounds.clip = dan;
        // play in chaMove.cs
    }

   
    public virtual IEnumerator pick()
    {
        if (!isFlower)
        {
            errorPick = 1;
            noPickUp();
            yield return new WaitForSeconds(3);
            errorPick = 0;
        }
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
