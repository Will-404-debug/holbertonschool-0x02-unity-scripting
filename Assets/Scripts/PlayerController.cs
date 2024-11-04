using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	public float speed = 5.0f; // Speed variable, can be modified in the Inspector

	private Rigidbody rb;

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
}