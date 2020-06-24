using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform playerBody, target;
	public float mouseSensitivity = 100f;
	float mouseX, mouseY;
	public bool isInverted;

	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update () {
		mouseX += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
		if (isInverted)
			mouseY -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
		else
			mouseY += Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
		mouseY = Mathf.Clamp(mouseY, -35f, 60f);

		transform.LookAt(target);

		target.rotation = Quaternion.Euler(mouseY, mouseX, 0f);
		playerBody.rotation = Quaternion.Euler(0f, mouseX, 0f);
	}
}
