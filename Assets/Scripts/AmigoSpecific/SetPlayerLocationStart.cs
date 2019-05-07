using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerLocationStart : MonoBehaviour {

    public GameObject thePlayer;

	// Use this for initialization
	void Start ()
    {
        Vector3 newPos = PlayerLocationController.futurePos;
        thePlayer.transform.position = newPos;
	}
}
