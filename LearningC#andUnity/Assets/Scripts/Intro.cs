using UnityEngine;
using System;

public class Intro : MonoBehaviour
{
	void Start ()
    {
        //How to write to the cmd prompt in normal C#
        Console.WriteLine("Welcome to C# training!");

        //How to write to the console in Unity
        Debug.Log("Welcome to C# training!");

        //If the System namespace were missing, you could write without declaring it
        System.Console.WriteLine("Weclome to C# training!");

        //Same with Unity namespace
        UnityEngine.Debug.Log("Welcome to C# training");

        //Calling the Call() method
        Call();
	}

    void Call()
    {
        //This is a method/function to be called in Start()
        //The lines of code in this method will be run when called

        Debug.Log("This is from the Call() Method!");
    }
	
}
