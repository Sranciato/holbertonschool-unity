using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public OptionsMenu optionsMenu;

	public void LevelSelect(int level)
	{
		optionsMenu.SetScene(level);
		SceneManager.LoadScene(level);
	}

	public void Options()
	{
		optionsMenu.SetScene(0);
		SceneManager.LoadScene(4);
	}

	public void QuitGame()
	{
		Debug.Log("Exited");
		Application.Quit();
	}
}
