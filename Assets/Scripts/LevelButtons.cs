
using UnityEngine;


public class LevelButtons : MonoBehaviour
{
    public AudioSource source; 
    public GameObject level1Vortex;
    public GameObject level2Vortex;
    public GameObject level3Vortex; 


    public void Level1()
    {
        source.Play();
        level1Vortex.SetActive(true);
        level2Vortex.SetActive(false);
        level3Vortex.SetActive(false);
        //SceneManager.LoadScene("Level1_Test");

    }
    public void Level2()
    {
        source.Play();
        level1Vortex.SetActive(false);
        level3Vortex.SetActive(false);
        level2Vortex.SetActive(true);
        //SceneManager.LoadScene("Level2_Test");
    }
    public void Level3()
    {
        source.Play();
        level3Vortex.SetActive(true);
        level1Vortex.SetActive(false);
        level2Vortex.SetActive(false);
        // sceneLoader.CallLoadScene("Level3_Test");

    }

    public void sourcePlay()
    {
        if (source != null)
        {
            source.Play();
        }
    }


}
