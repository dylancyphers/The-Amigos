using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocationController : MonoBehaviour {

    //this value is set when the player hits the trigger sprite for loading the next scene
    //when the next scene is actually loaded, another script will set the player position to this value
    public static Vector3 futurePos;

}
