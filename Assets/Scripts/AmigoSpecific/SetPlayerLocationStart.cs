using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerLocationStart : MonoBehaviour {

    public GameObject thePlayer;
    private GameObject[] life;
    private int qtdLife;

    // Use this for initialization
    void Start ()
    {
        Vector3 newPos = PlayerLocationController.futurePos;
        thePlayer.transform.position = newPos;
        life = GameObject.FindGameObjectsWithTag("Life");
        qtdLife = life.Length;
        if(PlayerLivesController.futureLives != 0)
        {
            for (int i = 0; i < 3 - PlayerLivesController.futureLives; i++)
            {
                Destroy(life[qtdLife - 1]);
                qtdLife -= 1;
            }
        }
        
    }
}
