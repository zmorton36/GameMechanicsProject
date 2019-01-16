using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private Rigidbody rb;
	[SerializeField]
	private bool canJump;
	[SerializeField]
	private float jump = 400;
	[SerializeField]
	public float speed;

	// Start is called before the first frame update
	void Start()
	{
		rb = gameObject.GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		//Movement
		Vector3 horizontal = gameObject.transform.right;
		rb.velocity = (Input.GetAxis("Horizontal") * horizontal * speed) + new Vector3(0, rb.velocity.y, 0);

		//Jumping
		if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
		{
			rb.AddForce(new Vector3(0, jump, 0));
			canJump = false;
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Wall")
		{
			canJump = true;
		}
	}

}

