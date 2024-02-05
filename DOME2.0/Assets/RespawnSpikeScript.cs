using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnSpikeScript : MonoBehaviour
{
    public GameObject respawnPoint;
    public GameObject player;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadSceneAsync(6);
        }
    }
}
