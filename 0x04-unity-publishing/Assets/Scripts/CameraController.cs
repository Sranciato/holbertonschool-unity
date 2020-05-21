using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = new Vector3(transform.position.x - player.transform.position.x, 0f, transform.position.z - player.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(player.transform.position.x + offset.x, transform.position.y, player.transform.position.z + offset.z);
	}
}
