using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Reload : MonoBehaviour
{
    public Button reloadButton;
    public string sceneToReload = "YourSceneName";

    private void Start()
    {
        if (reloadButton != null)
        {
            reloadButton.onClick.AddListener(ReloadScene);
        }
        else
        {
            Debug.LogError("Make sure to assign a Button component to reloadButton in the inspector.");
        }
    }

    void ReloadScene()
    {
        // Reload the specified scene instantly
        SceneManager.LoadScene(sceneToReload);
    }
}
