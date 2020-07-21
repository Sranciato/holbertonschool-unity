using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour {

	public Timer timer;
	public GameObject winCanvas;
	public AudioSource bgm;

	void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
		{
			bgm.Stop();
			timer.StopTimer();
			winCanvas.SetActive(true);
			Cursor.lockState = CursorLockMode.None;
		}
    }
}
