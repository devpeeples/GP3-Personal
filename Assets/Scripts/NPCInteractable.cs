using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    public bool simple;
    public bool complex;


    public bool shopCrab;



    private GameObject shopCrabParent;
    private GameObject[] shopCrabParents;
    //originalGameObject.transform.GetChild(0).gameObject;
    private GameObject shopCrabObject; 
    public GameObject simpleObj;
    public GameObject complexObj;
    private ShopButtons shopButtons; 

    public GameObject simpleShop;
    private GameObject gameManagerObject;
    private GameManager gameManager; 
  


    public void Interact()
    {

        shopCrabParents = GameObject.FindGameObjectsWithTag("ShopCrab");

        shopCrabParent = shopCrabParents[0].gameObject;

        shopCrabObject = shopCrabParent.transform.GetChild(0).gameObject;


        if (simple && !shopCrab)
        {
            simpleObj.SetActive(true);
        }
        else if (complex)
        {
            if (!complexObj.GetComponent<UINext>().isShowingNext)
            {
                complexObj.SetActive(true);
            }
        }
        else if (shopCrab)
        {


            shopCrabObject.SetActive(true);
            if (Input.GetButtonDown("Interact"))
            {
                gameManagerObject = GameObject.FindWithTag("GameManager");
                gameManager = gameManagerObject.GetComponent<GameManager>();
                shopButtons = shopCrabObject.GetComponent<ShopButtons>();
                gameManager.SaveGameData();
                shopButtons.SaveShop();
                shopCrabObject.SetActive(true);

            }
        }

    }
}
