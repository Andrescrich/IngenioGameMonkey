using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitoMovement : MonoBehaviour
{
    //Las variables con valores es mejor ponerlas en public asi aparecen en el inspector para modificarlas sin entrar a codigo
    private Rigidbody2D rb;
    public float velocity;
    private bool jump = false;
    public float jumpForce = 800f;
    public static MonitoMovement Instance;
    private bool isGrounded;

    void Start()
    {
        Physics2D.IgnoreLayerCollision(8, 9);
        rb = GetComponent<Rigidbody2D>();
        Instance = this;
    }

    void Update()
    {
        Debug.Log(isGrounded);
        if (Input.GetButtonDown("Jump") && GameManagerScript.inputEnabled && isGrounded)
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        //Movimiento hacia la derecha
        if(GameManagerScript.inputEnabled) rb.velocity = new Vector3(velocity, rb.velocity.y, 0);

        //Salto //El if tiene que tener {} cuando tienes mas de 1 cosa dentro de el, el jump=false no estaba dentro del if y se estaba poniendo a false
        //cada 20ns en vez de solo cuando pulsas jump
        if (jump)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = false;
    }
}
