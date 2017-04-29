using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameController : MonoBehaviour {

    public static GameController control;
    public int level;

	void Awake () {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        } else if(control != this)
        {
            Destroy(gameObject);
        }
	}

    void Start()
    {
        Load();
        Debug.Log(level);
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.playerLevel = LevelManager.currentLevel;

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            LevelManager.currentLevel = data.playerLevel;
            LevelManager.currentExperience = data.currentExperience;
        }
    }
}


[Serializable]
class PlayerData
{
    public int playerLevel = 50;
    public float currentExperience;
}