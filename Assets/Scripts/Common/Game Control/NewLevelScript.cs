using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewLevelScript : MonoBehaviour
{
    [SerializeField] private string newLevel;

    private GameObject[] life;
    private int qtdLife;

    public float posX;
    public float posY;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            life = GameObject.FindGameObjectsWithTag("Life");
            qtdLife = life.Length;
            SceneManager.LoadScene(newLevel);
            Vector3 newPos = new Vector3(posX, posY);
            PlayerLocationController.futurePos = newPos;
            PlayerLivesController.futureLives = qtdLife;
        }
    }
}
