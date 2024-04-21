using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkOpener : MonoBehaviour
{
    // URL to open
    public string linkToOpen = "x";

    // Function to open the link
    public void OpenLink()
    {
        Application.OpenURL(linkToOpen);
    }
}
