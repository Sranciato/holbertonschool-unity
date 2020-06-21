using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public CharacterController characterController;
	public float moveSpeed = 12f;
	public float jumpHeight = 3f;
	public float gravity = -9.81f;
	public LayerMask groundLayer;

	private Vector3 velocity;

	void LateUpdate()
	{
		if (transform.position.y < -10)
		{
			transform.position = new Vector3(0f, 100f, 0f);
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (isGrounded() && velocity.y < 0)
		{
			velocity.y = 0f;
		}

		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		Vector3 move = transform.right * x + transform.forward * z;

		characterController.Move(move * moveSpeed * Time.deltaTime);

		if (Input.GetButtonDown("Jump") && isGrounded())
		{
			velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
		}

		velocity.y += gravity * Time.deltaTime;
		characterController.Move(velocity * Time.deltaTime);
	}

	private bool isGrounded()
	{
		return Physics.Raycast(transform.position, -Vector3.up, 1.4f, groundLayer);
	}
}
