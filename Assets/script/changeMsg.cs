using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeMsg : MonoBehaviour
{
    string hint = "Hint: ";
  

    public int num;
    public int numOfStone;

    int errPick;
    int errSet;

    Text msg;
    Text numOfFlower;

    messages msgs;

    string[] hints;
    string[] err;

    string text = "Always dance with NPCs to get more hints\n(Press K while connecting)";
    int index = 0;


    manSounds data;
    // Start is called before the first frame update
    void Start()
    {
        msg = GameObject.Find("Canvas/Panel/message").GetComponent<Text>();

        msgs = new messages();
        hints = msgs.msg;
        err = msgs.error;

        numOfFlower = GameObject.Find("Canvas/Panel/TextOfFlower").GetComponent<Text>();
        data = transform.GetComponent<manSounds>();
    }

  

    // Update is called once per frame
    void Update()
    {
        getText();
        msg.text = hint + text;

        num = data.numOfFlower;
        numOfStone = data.numOfStone;
        numOfFlower.text = "Flower: " + num + "\nStone: " + numOfStone;
        

        errPick = data.errorPick;
        errSet = data.errorSet;

        if (errPick == 1)
        {
            msg.text = err[0];
        }
        else if (errSet == 1)
        {
            msg.text = err[1];
        }
        else
        {
            msg.text = hint + text;
        }
    }


    int giveMsg = 0;
    void getText()
    {
        if (giveMsg == 1)
        {
            if (index < 5)
            {
                int tempIndex = 0;
                foreach (string temp in hints)
                {
                    if (tempIndex == index)
                    {
                        text = temp;
                        break;
                    }
                    tempIndex += 1;
                }
                index += 1;
            }
            else
            {
                text = hints[0];
                index = 0;
            }
            giveMsg = 0;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "npc")
        {
            Animator npcAct = col.gameObject.GetComponent<Animator>();
            if (npcAct.GetBool("dance"))
            {
                giveMsg = 1;
            }
        }
    }
}
