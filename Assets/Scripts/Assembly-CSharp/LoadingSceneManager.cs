using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadingSceneManager : MonoBehaviour
{
    public string mainMenuSceneName = "MainMenu";
    public float loadingTime = 14f; // Bekleme s�resi (saniye)

    void Start()
    {
        StartCoroutine(LoadMainMenuAfterDelay());
    }

    IEnumerator LoadMainMenuAfterDelay()
    {
        yield return new WaitForSeconds(loadingTime);
        SceneManager.LoadScene(mainMenuSceneName); // MainMenu sahnesine ge�i� yap�l�r
    }
}