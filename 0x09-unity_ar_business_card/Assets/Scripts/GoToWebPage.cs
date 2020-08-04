using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToWebPage : MonoBehaviour
{
    public void buttonFunction(string url)
    {
        Application.OpenURL(url);
    }
}
