using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour {

	public GameObject player;
	private Timer timer;

	void Start()
	{
		timer = player.GetComponent<Timer>();
	}
	void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
		{
			timer.enabled = true;
		}
    }
}
