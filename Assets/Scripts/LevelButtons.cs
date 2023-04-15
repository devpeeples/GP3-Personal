using UnityEngine.SceneManagement;
using UnityEngine;


public class LevelButtons : MonoBehaviour
{
    public SceneLoader sceneLoader; 
    public void Level1()
    {
        SceneManager.LoadScene("Level1_Test");

    }
    public void Level2()
    {
        SceneManager.LoadScene("Level2_Test");
    }
    public void Level3()
    {
        
        sceneLoader.CallLoadScene("Level3_Test");

    }



}
