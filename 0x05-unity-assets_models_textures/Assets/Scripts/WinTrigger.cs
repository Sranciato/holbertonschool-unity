using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour {

	public Timer timer;

	void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
		{
			timer.StopTimer();
		}
    }
}
