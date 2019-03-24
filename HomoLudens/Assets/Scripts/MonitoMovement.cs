using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitoMovement : MonoBehaviour
{
    //Las variables con valores es mejor ponerlas en public asi aparecen en el inspector para modificarlas sin entrar a codigo
    private Rigidbody2D rb;
    public static float velocity = 4f;
    private bool jump = false;
    public float jumpForce = 800f;

    void Start()
    {
        Physics2D.IgnoreLayerCollision(8, 9);
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && GameManagerScript.inputEnabled)
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
}
