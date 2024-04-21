using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void Start()
    {
        // 8 saniye sonra Destroy() metodunu çaðýrarak objeyi yok eder.
        Destroy(gameObject, 8f);
    }
}