using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LaodScnee : MonoBehaviour
{
    public string schoolSceneName = "School";
    public float loadingTime = 14f; // Bekleme süresi (saniye)

    void Start()
    {
        StartCoroutine(LoadSchoolAfterDelay());
    }

    IEnumerator LoadSchoolAfterDelay()
    {
        yield return new WaitForSeconds(loadingTime);
        SceneManager.LoadScene(schoolSceneName); // MainMenu sahnesine geçiþ yapýlýr
    }
}