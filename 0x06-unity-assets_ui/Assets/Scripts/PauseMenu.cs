using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public Timer timer;
	public GameObject pauseCanvas;
	public GameObject optionsMenu;

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
	}

	public void Resume()
	{
		pauseCanvas.SetActive(false);
		Time.timeScale = 1;
		Cursor.lockState = CursorLockMode.Locked;
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
}
