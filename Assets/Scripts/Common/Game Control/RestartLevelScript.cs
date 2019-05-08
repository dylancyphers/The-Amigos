using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartLevelScript : MonoBehaviour
{

    public GameObject thePlayer;
    private GameObject[] life;
    private int qtdLife;


    void Start()
    {
        life = GameObject.FindGameObjectsWithTag("Life");
        qtdLife = life.Length;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            thePlayer.transform.position = PlayerLocationController.futurePos;
            Destroy(life[qtdLife - 1]);
            qtdLife -= 1;
        }
    }
}
