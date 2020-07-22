using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour {

	public Timer timer;
	public GameObject pauseCanvas;
	public GameObject optionsMenu;
	public AudioMixerSnapshot paused, unpaused;

	void Start()
	{
		Time.timeScale = 1;
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape) && !pauseCanvas.active)
		{
			Pause();
		}
		else if (Input.GetKeyDown(KeyCode.Escape) && pauseCanvas.active)
		{
			Resume();
		}
	}

	void Pause()
	{
		pauseCanvas.SetActive(true);
		Time.timeScale = 0;
		Cursor.lockState = CursorLockMode.None;
		paused.TransitionTo(.01f);
	}

	public void Resume()
	{
		pauseCanvas.SetActive(false);
		Time.timeScale = 1;
		Cursor.lockState = CursorLockMode.Locked;
		unpaused.TransitionTo(.01f);
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void MainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public void Options()
	{
		SceneManager.LoadScene("Options");
	}
	public void Next()
	{
		if (SceneManager.GetActiveScene().name == "Level03")
		{
			SceneManager.LoadScene("MainMenu");
		}
		else
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
