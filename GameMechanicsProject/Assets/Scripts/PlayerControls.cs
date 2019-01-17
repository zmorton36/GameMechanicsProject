using UnityEngine;

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
	private bool bigBool, littleBool;

	// Start is called before the first frame update
	void Start()
	{
		rb = gameObject.GetComponent<Rigidbody>();
		littleBool = true;
		bigBool = false;
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
			littleMove();

		if (bigBool && gameObject.tag == "BigBrother")
			bigMove();

	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Wall")
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
	}
}


