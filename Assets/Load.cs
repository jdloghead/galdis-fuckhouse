using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SahneDegistirici : MonoBehaviour
{
    public float beklemeSuresi = 10f; // Bekleme süresi (saniye)

    void Start()
    {
        StartCoroutine(BekleVeSahneDegistir());
    }

    IEnumerator BekleVeSahneDegistir()
    {
        yield return new WaitForSeconds(beklemeSuresi);
        SceneManager.LoadScene("MainMenu"); // "MainMenu" sahnesine geçiþ yapýlýr
    }
}