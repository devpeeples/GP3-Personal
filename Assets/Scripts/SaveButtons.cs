using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveButtons : MonoBehaviour
{
    private GameObject gameManagerObject;
    private GameManager gameManager;
    private ShopButtons shopButtons; 

    private GameObject[] shopCrabParents;
    private GameObject shopCrabParent;
    private GameObject shopCrabObject;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerObject = GameObject.Find("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();

    }

    public void SaveButton()
    {
        gameManager.SaveGameData();
        shopCrabParents = GameObject.FindGameObjectsWithTag("ShopCrab");

        shopCrabParent = shopCrabParents[0].gameObject;
        if (shopCrabParent != null)
        {
            shopCrabObject = shopCrabParent.transform.GetChild(0).gameObject;

            shopButtons = shopCrabObject.GetComponent<ShopButtons>();

            shopButtons.SaveShop();

           

        }



    }


    public void Delete()
    {
        SaveSystem.DeletePlayer();
        SaveSystem.DeleteShop();
        //SceneManager.LoadScene("Tutorial");
        Application.Quit();



    }
}
