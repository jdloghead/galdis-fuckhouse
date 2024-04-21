using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GaldSaveFileScreen : MonoBehaviour
{
    public GaldSaveFileSelectionPanel[] panels;

    public PlayerStats playerStats;
    public GameObject selectScreen;
    public GameObject newFileScreen;
    public GameObject loadingScreen; 
    public Sprite neilbackground;
    public Image background;
    public void Start()
    {
        if (PlayerPrefs.GetFloat("NeilScarySave") == 1)
        {
            music[0].gameObject.SetActive(false);
            music[1].gameObject.SetActive(false);

            background.sprite = neilbackground;
        }
    }

    public void OpenSaveMenu(int saveid)
    {
        foreach (GaldSaveFileSelectionPanel panel in panels)
        {
            if (saveid == panel.saveFileNumber)
            {
                if (panel.fileExists)
                    StartCoroutine(exitState(panel));
                else
                {
                    if (PlayerPrefs.GetFloat("PreventNewFiles") == 1)
                    {
                        SceneManager.LoadScene("NeilNewSave");
                    }
                    else
                    {
                        newFileScreen.SetActive(true);
                        selectScreen.SetActive(false);

                        inEditMode = true;

                        SetDefaultSaveValues();
                     
                        PlayerPrefs.SetInt("CurrentSave", saveid);
                    }
                }
            }
        }
    }

    public void SetDefaultSaveValues()
    {
        playerStats.data.name = "Player";
        playerStats.data.beatHardMode = false;
        playerStats.data.highBooks = 0;
        playerStats.data.theEnd = false;
        playerStats.data.storyModeWon = false;
    }

    IEnumerator exitState(GaldSaveFileSelectionPanel panel)
    {
        PlayerPrefs.SetInt("CurrentSave", panel.saveFileNumber);
        loadingScreen.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene("MainMenu");
    }

    public AudioSource[] music;
    public bool inEditMode = false;

    void Update()
    {
        if (!inEditMode)
        {
            if (music[0].volume < 1f)
                music[0].volume += Time.deltaTime / 2;
            if (music[1].volume > 0f)
                music[1].volume -= Time.deltaTime / 2;
        }
        else
        {
            if (music[1].volume < 1f)
                music[1].volume += Time.deltaTime / 2;
            if (music[0].volume > 0f)
                music[0].volume -= Time.deltaTime / 2;
        }
    }
}
