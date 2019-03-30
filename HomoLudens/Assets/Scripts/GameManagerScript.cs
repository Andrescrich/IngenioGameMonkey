using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public static bool inputEnabled;
    public static int vidas;
    public static GameManagerScript Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        inputEnabled = true;
        vidas = 10;
    }

    private void Update()
    {
        if(Input.GetButtonDown("Submit")) {
            SceneManager.LoadScene(0);
            GameManagerScript.vidas = 10;
            GameManagerScript.inputEnabled = true;
        }
    }
}
