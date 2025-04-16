using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class OnSceneLoadedDelegateScript : MonoBehaviour
{
    string leaderboardText;
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
            case 3:
                if (GameControllerScript.gameController.buttonGameCooldown >= 10)
                {
                    GameObject.Find("ButtonCooldownText").GetComponent<TextMeshProUGUI>().text = "00:" + (int)GameControllerScript.gameController.buttonGameCooldown;
                }
                else
                {
                    GameObject.Find("ButtonCooldownText").GetComponent<TextMeshProUGUI>().text = "00:0" + (int)GameControllerScript.gameController.buttonGameCooldown;
                }
                GameObject.Find("ButtonPointText").GetComponent<TextMeshProUGUI>().text = "Point: " + GameControllerScript.gameController.buttonGamePoints;
                switch (GameControllerScript.gameController.buttonGamePoints)
                {
                    case 7:
                        leaderboardText = "Leaderboard:" + "\n" + "\n";
                        leaderboardText += "1. TheLegend27: 9" + "\n";
                        leaderboardText += "2. User01032: 8" + "\n";
                        leaderboardText += "3. Dig!: 7";
                        GameObject.Find("LeaderboardText").GetComponent<TextMeshProUGUI>().text = leaderboardText;
                        break;
                    case 8:
                        leaderboardText = "Leaderboard:" + "\n" + "\n";
                        leaderboardText += "1. TheLegend27: 9" + "\n";
                        leaderboardText += "2. Dig!: 8" + "\n";
                        leaderboardText += "3. User01032: 8";
                        GameObject.Find("LeaderboardText").GetComponent<TextMeshProUGUI>().text = leaderboardText;
                        break;
                    case 9:
                        leaderboardText = "Leaderboard:" + "\n" + "\n";
                        leaderboardText += "1. Dig!: 9" + "\n";
                        leaderboardText += "2. TheLegend27: 9" + "\n";
                        leaderboardText += "3. User01032: 8";
                        GameObject.Find("LeaderboardText").GetComponent<TextMeshProUGUI>().text = leaderboardText;
                        break;
                    default:
                        break;
                }
                break;
                // add MathDone og YouLost scener
            default:
                break;
        }
    }
}
