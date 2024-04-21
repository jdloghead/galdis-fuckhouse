using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneToLoad; // The name of the scene you want to load

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
