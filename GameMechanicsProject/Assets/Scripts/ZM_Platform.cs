using UnityEngine;

public class ZM_Platform : MonoBehaviour
{
    public Transform platform;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "LittleBrother" || other.gameObject.tag == "BigBrother")
        {
            other.gameObject.transform.SetParent(platform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "LittleBrother" || other.gameObject.tag == "BigBerother")
        {
            other.gameObject.transform.SetParent(null);
        }
    }
}
