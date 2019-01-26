using UnityEngine;

public class P_PlateTrigger : MonoBehaviour
{
    public bool IsHere = false;

    [SerializeField]
    private Animator PlateAnim, OtherAnim;

    void OnCollisionEnter(Collision other)
    {
        IsHere = true;

       if(IsHere == true && (other.gameObject.tag == "Grabbable" || other.gameObject.tag == "LittleBrother" || other.gameObject.tag == "BigBrother"))
        {
            

            if(IsHere == true && PlateAnim.GetBool("PressureTrigger") == false)
            {
                PlateAnim.SetBool("PressureTrigger", true);
                OtherAnim.SetBool("PlayAnim", true);
            }
            
        }
    }

    void OnCollisionExit(Collision other)
    {
        if(IsHere == true)
        {
            IsHere = false;
            
            if(IsHere == false && PlateAnim.GetBool("PressureTrigger") == true)
            {
                PlateAnim.SetBool("PressureTrigger", false);
                OtherAnim.SetBool("PlayAnim", false);
            }
        }
    }
}
