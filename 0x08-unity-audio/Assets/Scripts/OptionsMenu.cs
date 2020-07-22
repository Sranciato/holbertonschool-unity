using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour {

	public GameObject invertYToggle;
	public AudioMixer masterMixer;
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
	public void SetMusicLvl(float musicLvl)
	{
		masterMixer.SetFloat("musicVol", musicLvl);
	}
	public void SetSfxLvl(float sfxLvl)
	{
		masterMixer.SetFloat("sfxVolume", sfxLvl);
	}
}
