using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public Text timerText;
	private float startTime, t = 0, holdTime = 0;
	private bool hasWon, pauseToggle;
	string saveTime = "";
	public Text winCanvasText;

	void Start()
	{
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		t = Time.time - startTime;
		
		if (!hasWon)
		{
			timerText.text = saveTime = string.Format("{0:0}:{1:00.00}", t / 60, t % 60);
		}
		else
		{
			Win();
		}

	}

	public void Win()
	{
		winCanvasText.text = saveTime;
		timerText.enabled = false;
	}

	public void StopTimer()
	{
		Debug.Log("called");
		hasWon = true;
	}
}
