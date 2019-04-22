using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneM2D : MonoBehaviour {

    [SerializeField] private string newLevel;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Application.LoadLevel(newLevel);
        }    
    }
}
