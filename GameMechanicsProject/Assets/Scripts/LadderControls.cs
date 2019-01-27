using UnityEngine;

public class LadderControls : MonoBehaviour
{
    [SerializeField]
    private int speed;

    private void OnTriggerStay(Collider other)
    {
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
        other.attachedRigidbody.useGravity = true;
    }
}

