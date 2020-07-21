using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSFX : MonoBehaviour
{
    public AudioSource myFx, myFx2;
    public AudioClip buttonRollover, buttonClick;

    public void HoverSound()
    {
        myFx.PlayOneShot(buttonRollover);
    }

    public void ClickSound()
    {
        myFx2.PlayOneShot(buttonClick);
    }
}
