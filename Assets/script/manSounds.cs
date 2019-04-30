using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manSounds : playerSoundPoly
{
  

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "mile")
        {
            isMile = true;
            mile = col.gameObject;
        }

        if (col.gameObject.tag == "npc")
        {
            Animator npcAct = col.gameObject.GetComponent<Animator>();
            if (npcAct.GetBool("death"))
            {
                if (col.gameObject.transform.GetChild(1).tag == "flower")
                {
                    isFlower = true;
                    flower = col.gameObject.transform.GetChild(1).gameObject;
                }

            }
        }

    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "mile")
        {
            isMile = false;
        }

    }




}
