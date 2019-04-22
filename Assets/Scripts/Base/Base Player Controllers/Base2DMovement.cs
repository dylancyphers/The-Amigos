//Also from Brackeys

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base2DMovement : MonoBehaviour {

    public CharacterController2D controller;

    public float runSpeed = 40f;

    public float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    public float verticalMove = 0f;

	// Update is called once per frame
	void Update () {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if(Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if(Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

	}

    void FixedUpdate()
    {
        //Movement occurs here
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
