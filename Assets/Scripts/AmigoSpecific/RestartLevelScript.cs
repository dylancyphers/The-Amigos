using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevelScript : MonoBehaviour
{

    public GameObject thePlayer;
    private GameObject[] life;
    private int qtdLife;



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            life = GameObject.FindGameObjectsWithTag("Life");
            qtdLife = life.Length;
            thePlayer.transform.position = PlayerLocationController.futurePos;
            Destroy(life[qtdLife - 1]);
            qtdLife -= 1;
            if(qtdLife <= 0)
            {
                SceneManager.LoadScene("d1");
            }
        }
    }
}
