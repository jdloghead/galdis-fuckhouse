using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomSplashText : MonoBehaviour
{
    public TMP_Text splashText; // Use TMP_Text for TextMesh Pro
    public string[] splashTexts;

    private void Start()
    {
        if (splashText != null && splashTexts.Length > 0)
        {
            // Choose a random splash text from the array
            int randomIndex = Random.Range(0, splashTexts.Length);
            string randomSplashText = splashTexts[randomIndex];

            // Update the TMP text with the random splash text
            splashText.text = randomSplashText;
        }
        else
        {
            Debug.LogError("Make sure to assign a TMP_Text component and provide splash texts in the inspector.");
        }
    }
}
