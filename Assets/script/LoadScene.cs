using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class LoadScene : MonoBehaviour
{
    public void Load(string levelName)
    {
        global.globalControl.isLoad = 0;
        SceneManager.LoadScene(levelName);
    }


    public void SaveAndBack(string levelName)
    {
        // load
        SaveByBin();
        global.globalControl.isSave = 1;

        // back
        SceneManager.LoadScene(levelName);
    }

    public void LoadLast()
    {
        // load scene
        if (global.globalControl.isSave == 1)
            LoadByBin();
        else
            Load("forest");
    }

    private Save saveGO()
    {
        Save save = new Save();

        Transform player = GameObject.Find("player").transform;

        save.x = player.position.x;
        save.y = player.position.y;
        save.z = player.position.z;

        save.numOfFlower = player.GetComponent<manSounds>().numOfFlower;
        save.numOfStone = player.GetComponent<manSounds>().numOfStone;

        if (player.tag == "woman")
        {
            save.nameOfScene = "desert";
        }if (player.tag == "man")
        {
            save.nameOfScene = "forest";
        }

        return save;
    }

    private void SaveByBin()
    {
        Save save = saveGO();
        BinaryFormatter bf = new BinaryFormatter();

        FileStream fileStream = File.Create(Application.dataPath + "/script/stream" + "/byBin.txt");
        bf.Serialize(fileStream, save);
        fileStream.Close();
    }

    private void LoadByBin()
    {
        global.globalControl.isLoad = 1;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fileStream = File.Open(Application.dataPath + "/script/stream" + "/byBin.txt", FileMode.Open);

        Save save = (Save)bf.Deserialize(fileStream);
        fileStream.Close();

        global.globalControl.save = save;
        SceneManager.LoadScene(save.nameOfScene);
    }
}
