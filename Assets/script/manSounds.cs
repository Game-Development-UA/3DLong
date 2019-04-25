using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manSounds : playerSoundPoly
{
  

    private void OnCollisionEnter(Collision col)
    {
        Animator npcAct = col.gameObject.GetComponent<Animator>();
        if (npcAct.GetBool("death"))
        {
            if(col.gameObject.transform.GetChild(1).tag == "flower")
            {
                isFlower = true;
                flower = col.gameObject.transform.GetChild(1).gameObject;
            }
        }
    }




}
