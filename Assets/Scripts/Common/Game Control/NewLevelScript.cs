using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewLevelScript : MonoBehaviour
{
    [SerializeField] private string newLevel;

    public float posX;
    public float posY;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(newLevel);
            Vector3 newPos = new Vector3(posX, posY);
            PlayerLocationController.futurePos = newPos;
        }
    }
}
