using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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
    private Animator anim;

    private int currentVida;

    void Start()
    {
        Physics2D.IgnoreLayerCollision(8, 9);
        rb = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        anim.SetBool("die", false);
        Instance = this;
        currentVida = GameManagerScript.vidas;
    }

    void Update()
    {
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
            FindObjectOfType<AudioManagerScript>().Play("Salto");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            FindObjectOfType<AudioManagerScript>().Play("pasosCesped");
            FindObjectOfType<AudioManagerScript>().Play("caidaSobreCesped");
        }

        if (collision.gameObject.tag == "obstacle")
        {
            if (GameManagerScript.vidas == currentVida)
            {
                anim.SetBool("die", true);
                GameManagerScript.inputEnabled = false;
                Invoke("restart", 2);
                FindObjectOfType<AudioManagerScript>().Play("Hit");
                GameManagerScript.vidas--;
            }
        }

        if (collision.gameObject.tag == "ChangeLevel")
        {
            GameObject.Find("LevelChanger").GetComponent<Animator>().SetTrigger("FadeOut");
            Invoke("ChangeLevelDelay", 1f);
        }

        if (collision.gameObject.tag == "Final") {
            GameObject.Find("LevelChanger").GetComponent<Animator>().SetTrigger("Final");
            Invoke("BackToMenu", 2f);
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = false;
        FindObjectOfType<AudioManagerScript>().Stop("pasosCesped");
    }

    void restart()
    {
        if (GameManagerScript.vidas > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            GameManagerScript.inputEnabled = true;
        }
        else if (GameManagerScript.vidas == 0)
            GameObject.Find("LevelChanger").GetComponent<Animator>().SetTrigger("Perder");
        Invoke("BackToMenu", 2f);
    }


    void ChangeLevelDelay() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void BackToMenu()
    {
        SceneManager.LoadScene(0);
        GameManagerScript.vidas = 10;
        GameManagerScript.inputEnabled = true;
    }
}
