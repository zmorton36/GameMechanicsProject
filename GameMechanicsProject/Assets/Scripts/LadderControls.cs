using UnityEngine;

public class LadderControls : MonoBehaviour
{
    //Public Declarations
    public GameObject ladderTop;
    public bool isClimbing = false;

    //Serialized Private Vars
    [SerializeField]
    private int speed;

    private void Start()
    {
        //Setting ladderTop off to avoid unneccesary collision
        ladderTop.gameObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        //Setting isClimbing to True
        isClimbing = true;

        //Turning the collider on while on ladder
        ladderTop.gameObject.SetActive(true);

        //Controls for ladder
        if (Input.GetKey(KeyCode.W) && (other.gameObject.tag == "BigBrother" || other.gameObject.tag == "LittleBrother"))
        {
            other.attachedRigidbody.useGravity = false; //Turning off Gravity 
            other.gameObject.transform.position += Vector3.up * speed * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.S) && (other.gameObject.tag == "BigBrother" || other.gameObject.tag == "LittleBrother"))
        {
            other.attachedRigidbody.useGravity = false; //Turning off Gravity
            other.gameObject.transform.position += Vector3.down * speed * Time.deltaTime;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Turning Gravity back on
        other.attachedRigidbody.useGravity = true;

        //Turning ladderTop collider back off
        ladderTop.gameObject.SetActive(false);

        //Turning isClimbing off
        isClimbing = false;
    }
}

