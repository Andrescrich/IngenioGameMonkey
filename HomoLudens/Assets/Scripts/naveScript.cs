using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class naveScript : MonoBehaviour
{
    private float velocity = 4f;
    private Rigidbody2D rb;
    private GameObject player;
    private bool empujar = true;
    private bool monoMoviendose = true;
    private bool naveMoviendose = false;
    private CinemachineVirtualCamera vcam;
    private CinemachineVirtualCamera vcam2;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        vcam = GameObject.FindGameObjectWithTag("vcam").GetComponent<CinemachineVirtualCamera>();
        vcam2 = GameObject.FindGameObjectWithTag("vcam2").GetComponent<CinemachineVirtualCamera>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector3(0f, velocity);
        if (empujar) Invoke("StopMoving", 2.5f);
        Invoke("MonitoVuelveAMoverse", 7f); 
        Invoke("NaveMoviendose", 7f);
        if (naveMoviendose) rb.velocity = new Vector3(6.75f, 0f);
    }

    void StopMoving()
    {
        velocity = 0f;
        if (empujar) { 
        player.GetComponent<Rigidbody2D>().AddForce(new Vector3(250f, 400f));
            vcam2.m_Priority = 9;
        vcam.m_Follow = player.transform;
        empujar = false;
        }
        MonitoMovement.Instance.velocity = 7;
    }

    void MonitoVuelveAMoverse()
    {
        if (monoMoviendose)
        {
            GameManagerScript.inputEnabled = true;
            monoMoviendose = false;
            FindObjectOfType<AudioManagerScript>().Play("Theme2");
            Debug.Log("A");
        }
    }

    void NaveMoviendose()
    {
        naveMoviendose = true;
    }
}
