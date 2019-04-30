using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class messages
{

    public string[] msg;
    public string[] error;

    public messages()
    {
        msg = new string[5] 
        {
        "Kill the same sex NPC to active the opposite sex NPC\n(Press J while connecting)",
        "Kill the opposite sex NPC to active the Flower",
        "Press S to pick up the Flower",
        "Press L to set up the Flower on the special stone",
        "Automatically enter the next level after set all flower"
        };

        error = new string[2]
        {
        "Nothing to pick here",
        "Nothing to set here"
        };
    }



}
