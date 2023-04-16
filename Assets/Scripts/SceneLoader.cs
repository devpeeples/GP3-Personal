using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        // Get the GameManager component attached to the Game Manager game object
        gameManager = GameObject.FindObjectOfType<GameManager>();

        // Call the Load method in the GameManager
        gameManager.LoadGameData();
    }

    public void CallLoadScene(string sceneName)
    {
        // Call the Save method in the GameManager before loading a new scene
        gameManager.SaveGameData();
        SceneManager.LoadScene(sceneName);
        gameManager.References();
        gameManager.LoadGameData();
        
        

        // Load the specified scene
      
    }
}
