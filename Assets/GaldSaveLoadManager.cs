using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class GaldSaveLoadManager
{
    public static void SavePlayer(PlayerData data)
    {
        string folderPath = GetCurrentPlatformPath();

        Directory.CreateDirectory(folderPath + "/GaldisFuckhouseSaves");

        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream1 = new FileStream(folderPath + "/GaldisFuckhouseSaves/" + PlayerPrefs.GetInt("CurrentSave").ToString() + ".gald", FileMode.Create);

        bf.Serialize(stream1, data);
        stream1.Close();
        Debug.Log("Saved!");

        if (GameObject.FindObjectOfType<PlayerStats>().showLoadIndication)
            GameObject.Instantiate(GameObject.FindObjectOfType<PlayerStats>().loadIndication);
    }

    public static PlayerData LoadPlayer(int saveid)
    {
        string folderPath = GetCurrentPlatformPath();

        if(!File.Exists(folderPath + "/GaldisFuckhouseSaves/" + saveid + ".gald")) 
            File.Create(folderPath + "/GaldisFuckhouseSaves/" + saveid + ".gald"); 
        

        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream1 = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/GaldisFuckhouseSaves/" + saveid + ".gald", FileMode.Open);
        PlayerData data = bf.Deserialize(stream1) as PlayerData;

        if (data == null)
            Debug.LogError("An error occured while loading save file '" + saveid + "' (File might not be compatible with current version?)");

        stream1.Close();
        return data;
    }

    public static string GetCurrentPlatformPath()
    {
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        #if UNITY_STANDALONE_OSX 
        folderPath = Application.persistentDataPath; 
        #endif
        
        return folderPath;
    }
}

[Serializable]
public class PlayerData
{
    public string name = "-";
    public bool beatHardMode = false;
    public int highBooks = 0;
    public bool theEnd = false;
    public bool storyModeWon = false;
}