using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    //Private Declarations
    private Rigidbody rb, rbItem;
    private bool activateJump;

    //Private Serialized Declarations
    [SerializeField]
    private float jump = 400, force = 100, trajectory;
	[SerializeField]
	private bool bigBool, littleBool, bigTutorial = false, littleTutorial= false, canJump;
    [SerializeField]
    private GameObject heldItem, Arrow = null, launchPoint = null;

    //Public Declarations
    public Collider lilBro, bigBro, heldCol;
    public Light lilLight, bigLight;
    public float speed;
   
	void Start()
	{
        //Getting the rigidbody
        rb = gameObject.GetComponent<Rigidbody>();

        //Asking if the player is in the tutorials
        if (littleTutorial == true)
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
		
        //Setting the BigBrother's arrow to off by default
		Arrow.SetActive(false);

        //Turning the BigBrother's Light off by default, and the Little Brother's on by default
        bigLight.gameObject.SetActive(false);
        lilLight.gameObject.SetActive(true);
		
        //Ignore collision between players
        Physics.IgnoreCollision(lilBro, bigBro);
	}

    private void Update()
    {
        //Calculating the trajectory of thrown objects
        trajectory = Vector3.Dot(gameObject.transform.right, Arrow.transform.right);

        //Switching player controls between Big and Little brother
        SwitchPlayers();
        
        //Setting bool to let player jump if they press "Space"
        if (littleBool == true && canJump == true && Input.GetKeyDown(KeyCode.Space))
        {
            activateJump = true;
        }
    }

    void FixedUpdate()
	{
        //if the player is playing as the Little Brother, use the Little Brother controls
        if (littleBool && gameObject.tag == "LittleBrother")
        {
            littleMove();
        }

        //if the player is playing as the Big Brother, use the Big Brother controls
        if (bigBool && gameObject.tag == "BigBrother")
        {
            bigMove();
        }

        //Throw the item that is held
        if(Input.GetKeyDown(KeyCode.Space) && bigBool == true && heldItem != null)
        {
            Throw();
        }
	}

	private void OnCollisionEnter(Collision collision)
	{
		//Checking if player is on the ground to jump
		if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Grabbable")
		{
			canJump = true;
		}
	}

    //Grabbing an item if playing as the Big Brother
	private void OnCollisionStay(Collision collision) 
	{
        //If the Big Brother collides with a grabbable object
		if (gameObject.tag == "BigBrother" && collision.gameObject.tag == "Grabbable")
		{
            //If the player isn't holding anything and presses space to pick up the item
            if (heldItem == null && (Input.GetKey(KeyCode.Space)))
			{   
                //The player is now holding the colliding object and it is kinematic
				heldItem = collision.gameObject;
				heldItem.gameObject.GetComponent<Rigidbody>().isKinematic = true;

                //Putting the held item at the launch point and getting its rigidbody
				heldItem.transform.position = launchPoint.transform.position;
				heldItem.transform.parent = Arrow.gameObject.transform;
				heldCol = heldItem.GetComponent<Collider>();
				rbItem = heldItem.gameObject.GetComponent<Rigidbody>();

                //Turning on the arrow
                Arrow.SetActive(true);

                //Making the mass low so it can be thrown easier
			    collision.gameObject.GetComponent<Rigidbody>().mass = 1;     
                
                //Increasing the mass of an object on collision so the Little Brother can't push them around
		        if (collision.gameObject.tag == "Grabbable" && gameObject.tag == "LittleBrother")
                {
                    collision.gameObject.GetComponent<Rigidbody>().mass = 200;
                }

            }
		}
	}

	private void littleMove()
	{
        //Enabling player controls with "A" and "D" to move horizontally
        Vector3 horizontal = gameObject.transform.right;
		rb.velocity = (Input.GetAxis("Horizontal") * horizontal * speed) + new Vector3(0, rb.velocity.y, 0);

        //Letting the player jump if "Space" is pressed
		if (activateJump && canJump == true)
		{
			rb.AddForce(new Vector3(0, jump, 0));
			canJump = false;
            activateJump = false;
		}
	}

	private void bigMove()
	{
        //Enabling player controls with "A" and "D" to move horizontally
        Vector3 horizontal = gameObject.transform.right;
		rb.velocity = (Input.GetAxis("Horizontal") * horizontal * speed) + new Vector3(0, rb.velocity.y, 0);
		
        //If the player is holding something, use the Aim() controls
		if (heldItem != null)
		{
            //Use Aim() controls
            Aim();
        }
	}

	private void Aim()
	{
        //"W" moves the trajectory up
        if (Input.GetKey(KeyCode.W))
		{
			Arrow.gameObject.transform.Rotate(0, 0, Time.deltaTime * 30);
		}

        //"S" moves the trajectory down
        if (Input.GetKey(KeyCode.S))
		{
			Arrow.gameObject.transform.Rotate(0, 0, Time.deltaTime * -30);
		}
	}

    private void Throw()
    {
        //Setting it back to its default state after being thrown
        heldItem.gameObject.GetComponent<Rigidbody>().isKinematic = false;

        //Finding the direction to throw it in and adding force to it
        if (trajectory > 0)
        {
            //This finds a trajectory and multiplies it by force in the X and Y
            rbItem.AddForce(new Vector3(trajectory * force, trajectory * force, 0));
        }
        if (trajectory < 0)
        {
            //This finds a trajectory and multiplies it by force in the X and Y
            //This also uses a negative in the Y to keep the force positive (because left on the Dot Product is negative)
            rbItem.AddForce(new Vector3((trajectory * force), -(trajectory * force), 0));
        }

        //Setting varaibles back to their default state when nothing is being held
        heldItem.transform.parent = null;
        Arrow.SetActive(false);
        heldCol = null;
        heldItem = null;
        rbItem = null;
    }

    private void SwitchPlayers()
    {
        //Switching player controls between Big and Little brother
        if (Input.GetKeyDown(KeyCode.E) && bigTutorial == false && littleTutorial == false)
        {
            if (littleBool == true)
            {
                littleBool = false;
                bigBool = true;
                bigLight.gameObject.SetActive(true);
                lilLight.gameObject.SetActive(false);
            }
            else if (littleBool == false)
            {
                bigBool = false;
                littleBool = true;
                bigLight.gameObject.SetActive(false);
                lilLight.gameObject.SetActive(true);
            }
        }
    }
}


