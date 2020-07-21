using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public CharacterController characterController;
	public AudioSource playerRunning;
	public AudioSource playerLanding;
	
	public float moveSpeed = 12f;
	public float jumpHeight = 3f;
	public float gravity = -9.81f;
	public LayerMask groundLayer;
	public Animator animator;
	private bool hasLanded = true, hasFallen = false;

	private Vector3 velocity;

	void LateUpdate()
	{
		if (transform.position.y < -15)
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
		if (transform.position.y < -14f)
		{
			hasFallen = true;
			animator.SetBool("IsFalling", true);
		}

		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		Vector3 move = transform.right * x + transform.forward * z;

		characterController.Move(move * moveSpeed * Time.deltaTime);

		if (Input.GetButtonDown("Jump") && isGrounded())
		{
			velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
			animator.SetTrigger("IsJumping");
		}
		if (!isGrounded())
				hasLanded = false;
		if (Input.GetKey(KeyCode.W))
		{
			animator.SetBool("IsRunning", true);
			if (!playerRunning.isPlaying && isGrounded())
				playerRunning.Play();
			else if (playerRunning.isPlaying && !isGrounded())
				playerRunning.Stop();
		}
		else
		{
			animator.SetBool("IsRunning", false);
			playerRunning.Stop();
		}
		if (isGrounded() && hasLanded == false)
		{
			animator.SetTrigger("HasLanded");
			hasLanded = true;
		}
		if (isGrounded() && hasFallen == true)
		{
			animator.SetBool("IsFalling", false);
			animator.SetTrigger("HasFallen");
			playerLanding.Play();
			hasFallen = false;
		}

		velocity.y += gravity * Time.deltaTime;
		characterController.Move(velocity * Time.deltaTime);
	}

	private bool isGrounded()
	{
		return Physics.Raycast(transform.position, -Vector3.up, 1.4f, groundLayer);
	}
}
