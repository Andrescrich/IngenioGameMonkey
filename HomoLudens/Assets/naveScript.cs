using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class naveScript : MonoBehaviour
{
    private float velocity = 4f;
    private Rigidbody2D rb;
    private GameObject player;
    private bool empujar = true;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector3(0f, velocity);
        if(empujar) Invoke("StopMoving", 2.5f);
    }

    void StopMoving()
    {
        velocity = 0f;
        if (empujar) { 
        player.GetComponent<Rigidbody2D>().AddForce(new Vector3(250f, 400f));
        empujar = false;
        }
        MonitoMovement.velocity = 4f;
    }
}
