using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadingBar : MonoBehaviour
{
    //public GameObject loadinScene;
    public static loadingBar instance;
    public Slider Bar;
    public float progress = 5;
    public int sceneNumber=0;
    

    // Start is called before the first frame update
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
    void Start()
    {
       // loadinScene.SetActive(true);
       

    }

    // Update is called once per frame
    void Update()
    {
        fillBar();
    }
    public void fillBar()
    {
         Bar.value += progress;
        if(Bar.value == 1)
        {
            sceneManager.instance.whichScene();
            Bar.value = 0;
            sceneManager.instance.loading.SetActive(false);

            //Bar.value = 0;

        }
        
        
    }

}
