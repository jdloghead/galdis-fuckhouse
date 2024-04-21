using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PlayerStats : MonoBehaviour
{
    public PlayerData data;
    [SerializeField] private bool loadOnAwake;
    private bool instanceLoadedAlready = false;
    public GameObject loadIndication;
    public bool showLoadIndication = false;

    void Start()
    {
        if (loadOnAwake)
            Load();
    }
    
    public void Save()
    {
        GaldSaveLoadManager.SavePlayer(data);
    }

    public void Load()
    {
        data = GaldSaveLoadManager.LoadPlayer(PlayerPrefs.GetInt("CurrentSave"));
    }

    public void ResetToDefaults()
    {
        data.beatHardMode = false;
        data.highBooks = 0;
        data.theEnd = false;
        data.storyModeWon = false;
        Save();
    }

    public void TryLoad() // Use this function before trying to get / set values in a Start() function
    {
        if (!instanceLoadedAlready)
        {
            Load();
            instanceLoadedAlready = true;
        }
    }
}
