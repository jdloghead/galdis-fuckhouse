using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miencraf : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("storyModeWon", 1);
        if (PlayerPrefs.GetInt("storyModeWon") == 0)
        {
            Galdcraft.SetActive(true);
        }
    }
    public GameObject Galdcraft;
}
