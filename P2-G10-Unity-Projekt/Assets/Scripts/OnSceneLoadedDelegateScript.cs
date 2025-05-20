using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class OnSceneLoadedDelegateScript : MonoBehaviour
{
    GameObject grayscale;
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
            case 0:
                GameControllerScript.gameController.timerMinutes = 12;
                GameControllerScript.gameController.timer10Seconds = 0;
                GameControllerScript.gameController.timerSeconds = 0;
                GameControllerScript.gameController.time = "12:00";
                GameControllerScript.gameController.firstTimeInfoScene = true;
                GameControllerScript.gameController.firstTimeVideoScene = true;
                GameControllerScript.gameController.firstTimeMessageScene = true;
                GameControllerScript.gameController.chosenAnswer1 = 0;
                GameControllerScript.gameController.chosenAnswer2 = 0;
                GameControllerScript.gameController.chosenAnswer3 = 0;
                GameControllerScript.gameController.timeSpentOnMath = 0;
                GameControllerScript.gameController.timeSpentOnVideo = 0;
                GameControllerScript.gameController.timeSpentOnMessages = 0;
                GameControllerScript.gameController.timeSpentOnButtonGame = 0;
                GameControllerScript.gameController.buttonGamePoints = 0;
                GameControllerScript.gameController.buttonGameCooldown = 0;
                GameControllerScript.gameController.skipInfoScreen = false;
                GameControllerScript.gameController.previousScene = 0;
                GameControllerScript.gameController.buttonNotificationReady = false;
                GameControllerScript.gameController.messageNotificationReady = false;
                GameControllerScript.gameController.messageNotificationCooldown = 25;
                GameControllerScript.gameController.amountOfMessagesReceived = 0;
                GameControllerScript.gameController.doNotSwipe = false;
                GameControllerScript.gameController.canSwipe = true;


                break;
            case 1:
                if (grayscale == null)
                {
                    grayscale = GameObject.Find("Grayscale");
                }
                grayscale.SetActive(false);
                GameControllerScript.gameController.timerActive = true;
                if (GameControllerScript.gameController.firstTimeInfoScene)
                {
                    GameControllerScript.gameController.FirstTimeNotification();
                    grayscale.SetActive(true);
                    //GameControllerScript.gameController.firstTimeInfoScreen = false;
                }
                break;
            case 2:
                GameObject.Find("Video Player").GetComponent<VideoController>().LoadRandomVideo();
                if (GameControllerScript.gameController.firstTimeVideoScene)
                {
                    GameControllerScript.gameController.MessageNotification();
                    GameControllerScript.gameController.firstTimeVideoScene = false;
                }
                break;
            case 3:
                if (GameControllerScript.gameController.firstTimeMessageScene)
                {
                    GameControllerScript.gameController.ButtonNotification();
                    GameControllerScript.gameController.firstTimeMessageScene = false;
                }
                GameControllerScript.gameController.messageNotificationReady = true;
                for (int i = 0; i <= GameControllerScript.gameController.amountOfMessagesReceived; i++)
                {
                    MessageController.messageController.ActivateMessage(i);
                    MessageController.messageController.messages[i].transform.GetChild(2).GetChild(0).GetComponent<Image>().sprite = GameControllerScript.gameController.messageReactions[i];
                }
                break;
            case 4:
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
            case 6:
            case 7:
                GameControllerScript.gameController.timerActive = false;
                break;
            default:
                break;
        }
    }
}
