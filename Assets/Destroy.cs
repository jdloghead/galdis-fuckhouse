using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void Start()
    {
        // 8 saniye sonra Destroy() metodunu �a��rarak objeyi yok eder.
        Destroy(gameObject, 8f);
    }
}