using UnityEngine;

public class LadderControls : MonoBehaviour
{
    public GameObject ladderTop;
    [SerializeField]
    private int speed;

    private void Start()
    {
        //Setting ladderTop off to avoid unneccesary collision
        ladderTop.gameObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        //Turning the collider on while on ladder
        ladderTop.gameObject.SetActive(true);

        if (Input.GetKey(KeyCode.W) && (other.gameObject.tag == "BigBrother" || other.gameObject.tag == "LittleBrother"))
        {
            other.attachedRigidbody.useGravity = false;
            other.gameObject.transform.position += Vector3.up * speed * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.S) && (other.gameObject.tag == "BigBrother" || other.gameObject.tag == "LittleBrother"))
        {
            other.attachedRigidbody.useGravity = false;
            other.gameObject.transform.position += Vector3.down * speed * Time.deltaTime;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Turning Gravity back on
        other.attachedRigidbody.useGravity = true;

        //Turning ladderTop collider back off
        ladderTop.gameObject.SetActive(false);
    }
}

