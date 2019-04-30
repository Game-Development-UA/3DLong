using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setUpMemFromBin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (global.globalControl.isLoad == 1)
        {
            Transform player = GameObject.Find("player").transform;
            player.Translate(new Vector3(global.globalControl.save.x,
                                         global.globalControl.save.y,
                                         global.globalControl.save.z));

            player.GetComponent<manSounds>().numOfFlower = 
                                        global.globalControl.save.numOfFlower;

            player.GetComponent<manSounds>().numOfStone =
                                        global.globalControl.save.numOfStone;

            GameObject cam = GameObject.Find("MainCamera");

            cam.transform.Translate(new Vector3(global.globalControl.save.cx,
                                         global.globalControl.save.cy,
                                         global.globalControl.save.cz));

            global.globalControl.isLoad = 0;
        }
    }

   
}
