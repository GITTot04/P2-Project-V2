using UnityEngine;
using UnityEngine.SceneManagement;

public class OnSceneLoadedDelegateScript : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch (scene.buildIndex)
        {
            // Slet timeractive = false i case 0 når MathDone og YouLost scener er added
            case 0:
                GameControllerScript.gameController.timerActive = false;
                GameControllerScript.gameController.timerMinutes = 12;
                GameControllerScript.gameController.timer10Seconds = 0;
                GameControllerScript.gameController.timerSeconds = 0;
                GameControllerScript.gameController.time = "12:00";
                GameControllerScript.gameController.firstTimeInfoScreen = true;
                GameControllerScript.gameController.chosenAnswer1 = 0;
                GameControllerScript.gameController.chosenAnswer2 = 0;
                GameControllerScript.gameController.chosenAnswer3 = 0;
                GameControllerScript.gameController.timeSpentOnMath = 0;
                GameControllerScript.gameController.timeSpentOnVideo = 0;
                GameControllerScript.gameController.timeSpentOnMessages = 0;
                GameControllerScript.gameController.timeSpentOnButtonGame = 0;
                break;
            case 1:
                GameControllerScript.gameController.timerActive = true;
                break;
                // add MathDone og YouLost scener
            default:
                break;
        }
    }
}
