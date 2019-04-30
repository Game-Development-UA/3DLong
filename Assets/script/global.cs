using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class global : MonoBehaviour
{
    public static global globalControl;

    public int isLoad = 0;
    public int isSave = 0;
    public Save save;

    private void Awake()
    {
        if (globalControl == null)
        {
            DontDestroyOnLoad(gameObject);
            globalControl = this;
        }
        else if (globalControl != null)
        {
            Destroy(gameObject);
        }
    }
}
