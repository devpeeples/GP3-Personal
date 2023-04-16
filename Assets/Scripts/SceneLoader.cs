using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    private GameManager gameManager;
    private ShopButtons shopButtons;


    private GameObject[] shopCrabParents;
    private GameObject shopCrabParent;
    private GameObject shopCrabObject;





    private void Start()
    {

        // Get the GameManager component attached to the Game Manager game object
        gameManager = GameObject.FindObjectOfType<GameManager>();

        // Call the Load method in the GameManager
        if (gameManager.CheckPlayerFile())
        {
            gameManager.LoadGameData();
        }
        else
        {
            gameManager.SaveGameData();

        }
        
       
        shopCrabParents = GameObject.FindGameObjectsWithTag("ShopCrab");

        shopCrabParent = shopCrabParents[0].gameObject;
        if (shopCrabParent != null)
        {
            shopCrabObject = shopCrabParent.transform.GetChild(0).gameObject;

            shopButtons = shopCrabObject.GetComponent<ShopButtons>();
            if (shopButtons.CheckShopFile())
            {
                shopButtons.LoadShop();
            }
            else
            {
                shopButtons.SaveShop();

            }
            
        }
        
        
    }

    public void CallLoadScene(string sceneNameString)
    {
        // Call the Save method in the GameManager before loading a new scene
        if(sceneNameString != "Tutorial")
        {
            
            gameManager.SaveGameData();

            if (sceneNameString == "PHUb")
            {

                shopCrabParents = GameObject.FindGameObjectsWithTag("ShopCrab");

                shopCrabParent = shopCrabParents[0].gameObject;

                shopCrabObject = shopCrabParent.transform.GetChild(0).gameObject;

                shopButtons = shopCrabObject.GetComponent<ShopButtons>();
                shopButtons.SaveShop();

            }
            SceneManager.LoadScene(sceneNameString);
            gameManager.References();
            gameManager.LoadGameData();
            shopButtons.LoadShop();
        }
        else if (sceneNameString == "Tutorial")
        {
            if (!gameManager.CheckPlayerFile())
            {
                gameManager.SaveGameData();

                if (sceneNameString == "PHUb")
                {

                    shopCrabParents = GameObject.FindGameObjectsWithTag("ShopCrab");

                    shopCrabParent = shopCrabParents[0].gameObject;

                    shopCrabObject = shopCrabParent.transform.GetChild(0).gameObject;

                    shopButtons = shopCrabObject.GetComponent<ShopButtons>();
                    shopButtons.SaveShop();

                }
                SceneManager.LoadScene(sceneNameString);
                gameManager.References();
                gameManager.LoadGameData();
                shopButtons.LoadShop();
            }

            else if(gameManager.CheckPlayerFile())
            {
                

                if (sceneNameString == "PHUb")
                {

                    shopCrabParents = GameObject.FindGameObjectsWithTag("ShopCrab");

                    shopCrabParent = shopCrabParents[0].gameObject;

                    shopCrabObject = shopCrabParent.transform.GetChild(0).gameObject;

                    shopButtons = shopCrabObject.GetComponent<ShopButtons>();

                }
                SceneManager.LoadScene(sceneNameString);
                gameManager.References();
                gameManager.LoadGameData();
                shopButtons.LoadShop();


            }
        }

        // Load the specified scene

    }
}
