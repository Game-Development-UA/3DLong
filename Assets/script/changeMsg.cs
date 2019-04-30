using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeMsg : MonoBehaviour
{
    string hint = "Hint: ";
    string flower = "Flower: ";

    int num;

    Text msg;
    Text numOfFlower;

    messages msgs;
    messages err;

    string temp = "Always dance with NPCs to get more hints\n(Press K while connecting)";

    // Start is called before the first frame update
    void Start()
    {
        msg = GameObject.Find("Canvas/Panel/message").GetComponent<Text>();
        msg.text = hint + "Always dance with NPCs to get more hints\n(Press K while connecting)";

        msgs = new messages();

        numOfFlower = GameObject.Find("Canvas/Panel/TextOfFlower").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        num = transform.GetComponent<manSounds>().numOfFlower;
        numOfFlower.text = flower + num;
      
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "npc")
        {
            Animator npcAct = col.gameObject.GetComponent<Animator>();
            if (npcAct.GetBool("dance"))
            {

            }
        }
    }
}
