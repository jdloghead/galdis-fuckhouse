using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LaodScnee : MonoBehaviour
{
    public string schoolSceneName = "School";
    public float loadingTime = 14f; // Bekleme s�resi (saniye)

    void Start()
    {
        StartCoroutine(LoadSchoolAfterDelay());
    }

    IEnumerator LoadSchoolAfterDelay()
    {
        yield return new WaitForSeconds(loadingTime);
        SceneManager.LoadScene(schoolSceneName); // MainMenu sahnesine ge�i� yap�l�r
    }
}