using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public Text scoreText;
	public Text healthText;
	public Rigidbody rb;
	public GameObject winLose;
	public GameObject winLoseText;
	private Text WLtext;
	public float speed = 30;
	private int score = 0;
	public int health = 5;
	// Use this for initialization
	void Start () {
		WLtext = winLoseText.GetComponent<Text>();
	}
	void Update ()
	{
		if (health == 0)
		{
			winLose.SetActive(true);
			WLtext.text = "Game Over!";
			WLtext.color = Color.white;
			winLose.GetComponent<Image>().color = Color.red;
			StartCoroutine(LoadScene(3f));
		}
		if (Input.GetKey(KeyCode.Escape))
		{
			SceneManager.LoadScene(0);
		}
	}

	IEnumerator LoadScene(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		SceneManager.LoadScene(0);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
		{
			rb.AddForce(0f, 0f, speed);
		}
		if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
		{
			rb.AddForce(0f, 0f, -speed);
		}
		if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
		{
			rb.AddForce(-speed, 0f ,0f);
		}
		if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
		{
			rb.AddForce(speed, 0f, 0f);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Pickup")
		{
			score += 1;
			Destroy(other.gameObject);
			SetScoreText();
		}
		if (other.tag == "Trap")
		{
			health -= 1;
			SetHealthText();
		}
		if (other.tag == "Goal")
		{
			winLose.SetActive(true);
			winLose.GetComponent<Image>().color = Color.green;
			WLtext.color = Color.black;
			WLtext.text = "You Win!";
			StartCoroutine(LoadScene(3f));
		}
	}

	void SetHealthText()
	{
		healthText.text = "Health: " + health.ToString();
	}

	void SetScoreText()
	{
		scoreText.text = "Score: " + score.ToString();
	}
}
