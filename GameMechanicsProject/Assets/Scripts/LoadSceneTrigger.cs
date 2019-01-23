using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadSceneTrigger : MonoBehaviour
{

    //Bools to check if both characters are in the trigger volume to transfer to next scene - Initially set to false
    public bool LittleWin = false, BigWin = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "LittleBrother" || other.tag == "BigBrother")
        {

            if (other.tag == "LittleBrother" && LittleWin != true)
            {
                LittleWin = true;
            }
            if (other.tag == "BigBrother" && BigWin != true)
            {
                BigWin = true;
            }
            if (LittleWin && BigWin)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }



        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "LittleBrother")
        {
            LittleWin = false;
        }
        else if (other.tag == "BigBrother")
        {
            BigWin = false;
        }
    }
}
