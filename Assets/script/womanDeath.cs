using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class womanDeath : npcPoly
{

    public override void actions()
    {
        if (player.tag == "man" && playerActions.GetBool("attack")
            && !thisAnime.GetBool("alive") && !thisAnime.GetBool("dance") && !thisAnime.GetBool("death"))
            StartCoroutine(deathAffect2());

        else
            base.actions();
    }

}
