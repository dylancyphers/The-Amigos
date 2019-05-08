using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{

    //destroys coin on collision with player
    void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }

       
    }
}

