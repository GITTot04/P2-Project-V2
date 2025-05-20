using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
    
    public void LoadMathScene(int buildIndex) 
    {
        GameControllerScript.gameController.skipInfoScreen = true;
        GameControllerScript.gameController.canSwipe = true;
        SceneManager.LoadScene(buildIndex);
    }
    
}
