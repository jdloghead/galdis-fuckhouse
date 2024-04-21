using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SahneDegistirici : MonoBehaviour
{
    public float beklemeSuresi = 10f; // Bekleme s�resi (saniye)

    void Start()
    {
        StartCoroutine(BekleVeSahneDegistir());
    }

    IEnumerator BekleVeSahneDegistir()
    {
        yield return new WaitForSeconds(beklemeSuresi);
        SceneManager.LoadScene("MainMenu"); // "MainMenu" sahnesine ge�i� yap�l�r
    }
}