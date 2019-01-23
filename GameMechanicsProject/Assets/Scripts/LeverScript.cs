using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    [SerializeField] bool Nexttolever = false;
    [SerializeField] GameObject leverzone;
    [SerializeField] GameObject Gatetolift;
    [SerializeField] Animation anim;
    [SerializeField] AudioSource leversound;
    [SerializeField] GameObject Gate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Nexttolever == true)
            {
                leversound.Play();
                Gate.transform.Translate(3, 3, 3);
                // https://www.youtube.com/watch?v=C9W4cN5uZUw is the source sound// 
            }
        }
    }
     void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BigBrother" && other.tag == "LittleBrother")
        {
            Nexttolever = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "BigBrother" && other.tag == "LittleBrother")
        {
            Nexttolever = false;
        }
    }
}
