using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {

	public GameObject invertYToggle;
	static int backScene;
	public static bool isInverted = true;
	bool prevInv;

	void Start()
	{
		prevInv = invertYToggle.GetComponent<Toggle>().isOn = isInverted;
	}

	public void Back()
	{
		isInverted = prevInv;
		SceneManager.LoadScene(backScene);
	}
	public void SetInverted()
	{
		isInverted = invertYToggle.GetComponent<Toggle>().isOn;
	}
	public void Apply()
	{
		SceneManager.LoadScene(backScene);

	}

	public void SetScene(int prevScene)
	{
		backScene = prevScene;
	}
}
