using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnter : MonoBehaviour
{
    public GameObject[] Activate;
    public BoxCollider col;
    private void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.SetInt("fuckhouse", 1);
        if (PlayerPrefs.GetInt("fuckhouse") == 0)
        {
            foreach (var item in Activate)
            {
                item.SetActive(true);
            }
            Destroy(this);
        }
    }
}