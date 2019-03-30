using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lifeManager : MonoBehaviour
{
    private int vidaTotal = 10;
    public int vida;
    public Image[] vidas;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("monito");

        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("monito");
        vida = GameManagerScript.vidas;

        for (int i = 0; i < vidas.Length; i++)
        {
            vidas[i].sprite = player.GetComponent<SpriteRenderer>().sprite;
        }
        for (int i = vida; i < vidas.Length; i++)
        {
            vidas[i].color = new Color(0f,0f,0f);
        }

    }
}
