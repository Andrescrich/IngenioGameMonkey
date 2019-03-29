using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class naveNormalScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject player;
    public float velocidad;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(velocidad, 0f);
        if(player.GetComponent<Animator>().GetBool("die"))
        {
            rb.velocity = Vector3.zero; 
        }
    }
}
