using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    [SerializeField] private bool Nexttolever1;
    [SerializeField] private bool Leverpressed;
    [SerializeField] GameObject leverzone;
    [SerializeField] Animator anim;
    [SerializeField] AudioSource leversound;
    [SerializeField] GameObject Gate;

    // Start is called before the first frame update
    void Start()
    {
        Nexttolever1 = false;
        
        Leverpressed = false;
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Nexttolever1 == true)
            {
                if (Leverpressed == false)
                {
                    
                    leversound.Play();
                    Leverpressed = true;
                
                    anim.Play("Gate1");
                }
                
               
                

                //Current Transform.Translate values are just filler, might replace with an animation
                
                // https://www.youtube.com/watch?v=C9W4cN5uZUw is the source sound// 
            }
        }
    }
     void OnTriggerStay(Collider other)
    {
        if (other.tag == "BigBrother" || other.tag == "LittleBrother")
        {
            Nexttolever1 = true;
            Leverpressed = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "BigBrother" || other.tag == "LittleBrother")
        {
            Nexttolever1 = false;
        }
    }
}
