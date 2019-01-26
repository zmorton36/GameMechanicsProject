using UnityEngine;

public class PlayerControls : MonoBehaviour
{
	
	private Rigidbody rb, rbItem;
	[SerializeField]
	private bool canJump;
	[SerializeField]
	private float jump = 400,force = 100;
	[SerializeField]
	public float speed;
	[SerializeField]
	private bool bigBool, littleBool, bigTutorial = false, littleTutorial= false;
    [SerializeField]
    private GameObject heldItem, Arrow = null, launchPoint = null;
    public Camera bigCam, lilCam;
    public Collider lilBro, bigBro, heldCol;
	private float trajectory;

	// Start is called before the first frame update
	void Start()
	{
		rb = gameObject.GetComponent<Rigidbody>();
		if(littleTutorial == true)
		{
			littleBool = true;
			bigBool = false;
		}
		else if(bigTutorial == true)
		{
			littleBool = false;
			bigBool = true;
		}
		else
		{
			littleBool = true;
			bigBool = false;
		}
		
		Arrow.SetActive(false);
		
		
		//if (littleTutorial == true)
		//{
		//	bigCam.gameObject.SetActive(false);
		//}
		//else if (bigTutorial == true)
		//{
		//	lilCam.gameObject.SetActive(false);
		//}
		
		
        //Ignore collision between players
        Physics.IgnoreCollision(lilBro, bigBro);
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (Input.GetKeyDown(KeyCode.E) && bigTutorial == false && littleTutorial == false)
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

	private void Update()
	{
		trajectory = Vector3.Dot(gameObject.transform.right, Arrow.transform.right);
		//Debug.Log(trajectory);
	}

	private void OnCollisionEnter(Collision collision)
	{

		//Checking if player is on the ground to jump
		if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Grabbable")
		{
			canJump = true;
		}
      
		if(collision.gameObject.tag == "Grabbable")
		{
			collision.gameObject.GetComponent<Rigidbody>().mass = 200;
		}
	}

	



	private void OnCollisionStay(Collision collision)
	{

		if (gameObject.tag == "BigBrother" && collision.gameObject.tag == "Grabbable")
		{
			if (heldItem == null && (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Space)))
			{

				heldItem = collision.gameObject;
				heldItem.gameObject.GetComponent<Rigidbody>().isKinematic = true;
				//if (heldItem.transform.position.x > transform.position.x)
				//{
				//	heldItem.transform.Translate(.65f, .5f, 0);
				//}
				//else
				//{
				//	heldItem.transform.Translate(-.65f, .5f, 0);
				//}

				heldItem.transform.position = launchPoint.transform.position;
				heldItem.transform.parent = Arrow.gameObject.transform;
				heldCol = heldItem.GetComponent<Collider>();
				rbItem = heldItem.gameObject.GetComponent<Rigidbody>();
				Arrow.SetActive(true);
				if (collision.gameObject.tag == "Grabbable")
				{
					collision.gameObject.GetComponent<Rigidbody>().mass = 1;
				}
			}
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
		
		if (heldItem != null)
		{
			Aim();
		}

		if (Input.GetKeyDown(KeyCode.Space) && rbItem != null)
		{


			heldItem.gameObject.GetComponent<Rigidbody>().isKinematic = false;
			if (trajectory > 0)
			{
				rbItem.AddForce(new Vector3(trajectory * force, trajectory * force, 0));
			}
			if (trajectory < 0)
			{
				rbItem.AddForce(new Vector3((trajectory * force), -(trajectory * force), 0));
			}

			heldItem.transform.parent = null;
			Arrow.SetActive(false);
			heldCol = null;
			heldItem = null;
			rbItem = null;
		}
	}

	private void Aim()
	{
		if (Input.GetKey(KeyCode.W))
		{
			Arrow.gameObject.transform.Rotate(0, 0, Time.deltaTime * 30);
		}
		if (Input.GetKey(KeyCode.S))
		{
			Arrow.gameObject.transform.Rotate(0, 0, Time.deltaTime * -30);
		}
	}
}


