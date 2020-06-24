using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour {

	public Timer timer;
	public GameObject winCanvas;

	void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
		{
			timer.StopTimer();
			winCanvas.SetActive(true);
			Cursor.lockState = CursorLockMode.None;
		}
    }
}
