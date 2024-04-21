using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GaldSaveFileCreation : MonoBehaviour
{
    public PlayerStats stats;
    public InputField text;

    void Awake()
    {
        text.text = "";
    }


    void Update()
    {
        stats.data.name = text.text;
    }

    public void SaveAndMenu()
    {
        stats.Save();
        SceneManager.LoadScene("MainMenu");
    }
}
