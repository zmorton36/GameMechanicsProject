﻿using UnityEngine;

public class PlayerControls : MonoBehaviour
{
	private Rigidbody rb;
	[SerializeField]
	private bool canJump;
	[SerializeField]
	private float jump = 400;
	[SerializeField]
	public float speed;
	[SerializeField]
	private bool bigBool, littleBool, canHold;
    [SerializeField]
    private GameObject heldItem, Targeter, Arrow = null;
	[SerializeField]
	private Transform playerPosition;
    public Camera bigCam, lilCam;
    public Collider lilBro, bigBro;

	// Start is called before the first frame update
	void Start()
	{
		rb = gameObject.GetComponent<Rigidbody>();
		littleBool = true;
		bigBool = false;

		if(gameObject.tag == "BigBrother")
		{
			playerPosition = GetComponent<Transform>();
		}
		
        //Ignore collision between players
        Physics.IgnoreCollision(lilBro, bigBro);
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			if (littleBool == true)
			{
				littleBool = false;
				bigBool = true;
			}
			else if (littleBool == false)
			{
				bigBool = false;
				littleBool = true;
			}
		}
		if (littleBool && gameObject.tag == "LittleBrother")
        {
            littleMove();
            lilCam.gameObject.SetActive(true);
            bigCam.gameObject.SetActive(false);
        }

		if (bigBool && gameObject.tag == "BigBrother")
        {
            bigMove();
            lilCam.gameObject.SetActive(false);
            bigCam.gameObject.SetActive(true);
        }

	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Grabbable")
		{
			canHold = true;
			if (canHold == true)
			{
				heldItem = collision.gameObject;
				heldItem.gameObject.GetComponent<Rigidbody>().isKinematic = true;
			}
		}
		else
		{
			canHold = false;
			heldItem = null;
		}

		//Checking if player is on the ground to jump
		if (collision.gameObject.tag == "Floor")
		{
			canJump = true;
		}
      
	}

    private void littleMove()
	{
		Vector3 horizontal = gameObject.transform.right;
		rb.velocity = (Input.GetAxis("Horizontal") * horizontal * speed) + new Vector3(0, rb.velocity.y, 0);

		if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
		{
			rb.AddForce(new Vector3(0, jump, 0));
			canJump = false;
		}
	}

	private void bigMove()
	{
		Vector3 horizontal = gameObject.transform.right;
		rb.velocity = (Input.GetAxis("Horizontal") * horizontal * speed) + new Vector3(0, rb.velocity.y, 0);

        if (Input.GetKeyDown(KeyCode.Space) && canHold == true)
        {
            heldItem.transform.parent = transform;
			Targeter = Instantiate(Arrow, playerPosition.transform.position + (playerPosition.transform.right * 2), Quaternion.Euler(new Vector3(0, 0, 90)));
			Targeter.transform.parent = transform;
			canHold = false;
            
        }
        else if (Input.GetKeyDown(KeyCode.Space) && canHold == false)
        {
            heldItem.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            heldItem.transform.parent = null;
			Destroy(Targeter);
        }
    }
}


