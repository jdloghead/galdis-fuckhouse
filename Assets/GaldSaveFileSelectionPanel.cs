using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

using TMPro;

public class GaldSaveFileSelectionPanel : MonoBehaviour
{
    public PlayerData data;

    [Header ("UI")]
    public TextMeshProUGUI nameText;
    public Image createButtonText;
    public GameObject deleteSaveButton;
    public Image plrimg;
    public Sprite neilIcon;
    public GameObject[] badges;

    public Sprite play;
    public Sprite create;

    [Header ("Varriables")]
    public int saveFileNumber;
    
    [HideInInspector] public bool fileExists;
    private AudioSource sounds;

    IEnumerator Start()
    {
        string folderPath = GaldSaveLoadManager.GetCurrentPlatformPath();

        if (saveFileNumber != PlayerPrefs.GetInt("CurrentSave") && PlayerPrefs.GetFloat("NeilScarySave") == 1)
            gameObject.SetActive(false);

        if (base.GetComponent<AudioSource>() != null)
            sounds = base.GetComponent<AudioSource>();
        else
        {
            sounds = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
            sounds.loop = false;
            sounds.playOnAwake = false;
        }

        if(File.Exists(folderPath + "/GaldisFuckhouseSaves/" + saveFileNumber + ".gald"))
        {
            data = GaldSaveLoadManager.LoadPlayer(saveFileNumber);
            
            createButtonText.sprite = play;
            nameText.text = data.name;
            deleteSaveButton.SetActive(true);

            fileExists = true;

            if (data.storyModeWon)
                badges[0].SetActive(true);
            if (data.beatHardMode)
                badges[1].SetActive(true);
            if (data.theEnd)
                badges[2].SetActive(true);
        }
        else
        {
            createButtonText.sprite = create;
            nameText.text = "Empty";

            deleteSaveButton.SetActive(false);

            plrimg.color = Color.black;

            fileExists = false;
        }

        if (saveFileNumber == PlayerPrefs.GetInt("CurrentSave") && PlayerPrefs.GetFloat("NeilScarySave") == 1)
        {
            deleteSaveButton.SetActive(false);
            nameText.text = "01001110 01000101 01001001 01001100";
            nameText.color = Color.black;
        }
            

        yield return null;
    }

    public void DeleteFile()
    {
        string folderPath = GaldSaveLoadManager.GetCurrentPlatformPath();

        if (PlayerPrefs.GetFloat("PreventNewFiles") != 1)
        {
            File.Delete(folderPath + "/GaldisFuckhouseSaves/" + saveFileNumber + ".gald");
            SceneManager.LoadScene("SaveFileSelection");
        }
        else
        {
            SceneManager.LoadScene("NeilNewSave");
        }
    }
}
