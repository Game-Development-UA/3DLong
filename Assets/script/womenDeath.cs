using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class womenDeath : npcPoly
{

    public override void actions()
    {
        if (player.tag == "man" && playerActions.GetBool("attack"))
            StartCoroutine(deathAffect2());
        else
            base.actions();
    }

}
