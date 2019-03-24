using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitoMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private float velocity = 4f;
    private bool jump = false;
    private float jumpForce = 800f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        //Movimiento hacia la derecha
        rb.velocity = new Vector3(velocity, rb.velocity.y, 0);

        //Salto
        if (jump) rb.AddForce(new Vector2(0f, jumpForce));
        jump = false;
    }
}
