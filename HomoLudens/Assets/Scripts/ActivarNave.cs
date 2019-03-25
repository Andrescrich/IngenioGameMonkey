using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ActivarNave : MonoBehaviour
{
    private GameObject player;
    private GameObject nave;
    private CinemachineVirtualCamera vcam2;
    private CinemachineVirtualCamera vcam;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        nave = GameObject.FindGameObjectWithTag("Nave");
        vcam = GameObject.FindGameObjectWithTag("vcam").GetComponent<CinemachineVirtualCamera>();
        vcam2 = GameObject.FindGameObjectWithTag("vcam2").GetComponent<CinemachineVirtualCamera>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject == player)
        {
            vcam2.m_Priority = 11;
            MonitoMovement.Instance.velocity = 0f;
            GameManagerScript.inputEnabled = false;
            player.transform.position = new Vector3(39.2f, -4.894f, 0f);
            Invoke("ActivaNave", 2f);
            vcam.m_Follow = null;
        }
    }

    void ActivaNave()
    {
        nave.GetComponent<naveScript>().enabled = true;
        vcam.m_Follow = nave.transform;
    }
}
