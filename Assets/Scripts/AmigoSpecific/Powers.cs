using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powers : MonoBehaviour {

    public static bool doubleJump;
    public static bool wallJump;
    public static bool sprint;
    public static bool crouch;
    // Use this for initialization
    void Start () {

        doubleJump = false;
        wallJump = false;
        sprint = false;
        crouch = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public static void FoundDoubleJump()
    {
        doubleJump = true;
    }
    public static void FoundWallJump()
    {
        wallJump = true;
    }
    public static void FoundSprint()
    {
        sprint = true;
    }
    public static void FoundCrouch()
    {
        crouch = true;
    }



}
