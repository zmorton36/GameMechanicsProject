using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SplashAnim_TH : MonoBehaviour
{

	[SerializeField]
	private Animator Splash;
	[SerializeField]
	private bool splashDone = false;
	
    // Start is called before the first frame update
    void Start()
    {
		
	}

	private void Update()
	{

		if (Splash.GetCurrentAnimatorStateInfo(0).IsName("SplashNext"))
		{
			splashDone = true;
		}
		if(splashDone)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}
}
