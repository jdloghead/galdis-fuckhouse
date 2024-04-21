using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadingSceneManager : MonoBehaviour
{
    public string mainMenuSceneName = "MainMenu";
    public float loadingTime = 14f; // Bekleme süresi (saniye)

    void Start()
    {
        StartCoroutine(LoadMainMenuAfterDelay());
    }

    IEnumerator LoadMainMenuAfterDelay()
    {
        yield return new WaitForSeconds(loadingTime);
        SceneManager.LoadScene(mainMenuSceneName); // MainMenu sahnesine geçiþ yapýlýr
    }
}