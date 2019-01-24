using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_PlateTrigger : MonoBehaviour
{

    public bool IsHere = false;

    [SerializeField]
    private Animator PlateAnim;


    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        IsHere = true;

       if(IsHere == true && other.gameObject.tag == "Grabbable" || other.gameObject.tag == "LittleBrother" || other.gameObject.tag == "BigBrother")
        {
            

            if(IsHere == true && PlateAnim.GetBool("PressureTrigger") == false)
            {
                PlateAnim.SetBool("PressureTrigger", true);
                
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
            }
        }
    }
}
