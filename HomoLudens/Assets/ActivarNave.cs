using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarNave : MonoBehaviour
{
    private GameObject player;
    private GameObject nave;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        nave = GameObject.FindGameObjectWithTag("Nave");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject == player)
        {
            MonitoMovement.velocity = 0f;
            GameManagerScript.inputEnabled = false;
            player.transform.position = new Vector3(39.2f, -4.7f, 0f);
            Invoke("ActivaNave", 2f);
        }
    }


    void ActivaNave()
    {
        nave.GetComponent<naveScript>().enabled = true;
    }
}
