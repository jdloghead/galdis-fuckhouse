using TMPro;
using UnityEngine;

public class TipScript : MonoBehaviour
{
    private void Awake()
    {
        text.text = "Tip: " + tips[Random.Range(0, tips.Length)];
    }

    [SerializeField]
    private TMP_Text text;

    public string[] tips;
}