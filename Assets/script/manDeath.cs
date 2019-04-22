using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manDeath : npcPoly
{

    public override void actions()
    {
        if (player.tag == "woman" && playerActions.GetBool("attack"))
        {
            StartCoroutine(deathAffect2());
        }
        else
            base.actions();

    }

}
