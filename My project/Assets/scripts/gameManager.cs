using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;
    public float rotationSpeed = 10f; 
    public GameObject setting;
    public GameObject settingMenu;
    public GameObject closeButton;
    public Image LOGO;
    public Sprite newSprite;


    [Header("Animation")]
    public RectTransform LogoTransform;
    public RectTransform PlayButtonTransform;
    public float pullUpDistance = 200f;
    public float pullDownDistance = -400f;

    public float animationDuration = 0.5f; 
    private Vector2 LogoPosition;
    private Vector2 PlayPosition;

    [Header("Inventory")]
    public GameObject InventoryList;
    //public GameObject CloseButton;
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
    private void Start()
    {
        if (LogoTransform == null)
        {
            Debug.LogError("Image Transform is not assigned.");
            return;
        }
        LogoPosition = LogoTransform.anchoredPosition;





        if (PlayButtonTransform == null)
        {
            Debug.LogError("Image Transform is not assigned.");
            return;
        }
        PlayPosition = PlayButtonTransform.anchoredPosition;
    }

    void Update()
    {
        setting.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
    public void settingOpen()
    {
        Debug.Log("setting clicked");
        settingMenu.SetActive(true);
        closeButton.SetActive(true);
    }
    public void OnClickCloseButton()
    {
        settingMenu.SetActive(false);
        closeButton.SetActive(false);
    }
    public void play()
    {
        sceneManager.instance.sceneNumber= 1;
        OnPullUpButtonClick();
        
    }
    public void OnPullUpButtonClick()
    {
        StartCoroutine(PullUpCoroutine());
    }

    private IEnumerator PullUpCoroutine()
    {
        Vector2 targetPosition = LogoPosition + new Vector2(0, pullUpDistance);
        float elapsedTime = 0f;

        while (elapsedTime < animationDuration)
        {
            LogoTransform.anchoredPosition = Vector2.Lerp(LogoPosition, targetPosition, elapsedTime / animationDuration);
            elapsedTime += Time.deltaTime * 5;
            yield return null;
        }

        LogoTransform.anchoredPosition = targetPosition;
        StartCoroutine(PullDownCoroutine());
    }
    private IEnumerator PullDownCoroutine()
    {
        Vector2 targetPosition = PlayPosition + new Vector2(0, pullDownDistance);
        float elapsedTime = 0f;

        while (elapsedTime < animationDuration)
        {
            PlayButtonTransform.anchoredPosition = Vector2.Lerp(PlayPosition, targetPosition, elapsedTime / animationDuration);
            elapsedTime += Time.deltaTime * 5;
            yield return null;
        }

        PlayButtonTransform.anchoredPosition = targetPosition;
        LOGO.sprite = newSprite;
        yield return new WaitForSeconds(1.0f);
        sceneManager.instance.loading.SetActive(true);
        sceneManager.instance.lobby.SetActive(false);
    }
    public void openInventory()
    {
        InventoryList.SetActive(true);
    }
    public void closeInventory()
    {
        InventoryList.SetActive(false);
    }
}
