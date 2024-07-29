using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public static sceneManager instance;
    public GameObject lobby;
    public GameObject Game;
    public GameObject loading;
    public int sceneNumber = 0;
    
    
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void whichScene()
    {
        if (sceneNumber == 0)
        {
            lobby.SetActive(true);
        }
        if (sceneNumber== 1)
        {
            Game.SetActive(true);
        }
    }   
}
