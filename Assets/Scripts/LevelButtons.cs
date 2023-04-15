using UnityEngine.SceneManagement;
using UnityEngine;


public class LevelButtons : MonoBehaviour
{
    public SceneLoader sceneLoader;
    public GameObject level1Vortex;
    public GameObject level2Vortex;
    public GameObject level3Vortex; 


    public void Level1()
    {
        level1Vortex.SetActive(true);
        level2Vortex.SetActive(false);
        level3Vortex.SetActive(false);
        //SceneManager.LoadScene("Level1_Test");

    }
    public void Level2()
    {
        level1Vortex.SetActive(false);
        level3Vortex.SetActive(false);
        level2Vortex.SetActive(true);
        //SceneManager.LoadScene("Level2_Test");
    }
    public void Level3()
    {
        level3Vortex.SetActive(true);
        level1Vortex.SetActive(false);
        level2Vortex.SetActive(false);
        // sceneLoader.CallLoadScene("Level3_Test");

    }



}
