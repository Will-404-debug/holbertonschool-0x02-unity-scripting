﻿using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	public float speed = 5.0f; // Speed variable, can be modified in the Inspector

	private Rigidbody rb;

	private int score = 0; // Private score variable initialized to 0

	public int health = 5; // Public health variable initialized to 5

	void Start()
	{
		rb = GetComponent<Rigidbody>(); // Get the Rigidbody component attached to the Player
	}

	void FixedUpdate()
	{
		// Get input from WASD or Arrow keys
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		// Create a movement vector
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		
		// Move the Player
		rb.MovePosition(transform.position + movement * speed * Time.fixedDeltaTime);
	}

	// This function is called when another collider enters the trigger collider attached to this object
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Pickup")) // Check if the other object has the tag "Pickup"
		{
			score++; // Increment the score
			Debug.Log("Score: " + score); // Log the score to the console
			other.gameObject.SetActive(false); // Disable the Coin GameObject
			// Alternatively, you could destroy the Coin: Destroy(other.gameObject);
		}
		else if (other.CompareTag("Trap")) // Check if the other object has the tag "Trap"
		{
			health--; // Decrement the health
			Debug.Log("Health: " + health); // Log the health to the console

			// Optionally, you can add logic to handle what happens when health reaches zero
			if (health <= 0)
			{
				Debug.Log("Game Over"); // Example of game over condition
				// Here, you can add further logic for game over, respawning, etc.
			}
		}
	}
}