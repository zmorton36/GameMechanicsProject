using UnityEngine;

public class ZM_TriggerDetection : MonoBehaviour
{
    public Animator objectAnim;

    private void OnTriggerEnter(Collider other)
    {
        objectAnim.SetBool("PlayAnim", true);
    }
}
