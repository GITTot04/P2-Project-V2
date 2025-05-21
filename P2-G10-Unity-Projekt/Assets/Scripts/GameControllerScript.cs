using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameControllerScript : MonoBehaviour
{
    public static GameControllerScript gameController;
    public bool swipeDirection;
    public bool canSwipe = true;
    public bool firstTimeInfoScene = true;
    public bool timerActive = false;
    public int timerMinutes = 12;
    public int timer10Seconds;
    public float timerSeconds;
    public string time;
    public int chosenAnswer1;
    public int chosenAnswer2;
    public int chosenAnswer3;
    public int correctAnswerOption1 = 2;
    public int correctAnswerOption2 = 1;
    public int correctAnswerOption3 = 2;
    public bool answer1Result = false;
    public bool answer2Result = false;
    public bool answer3Result = false;
    public float timeSpentOnMath;
    public float timeSpentOnVideo;
    public float timeSpentOnMessages;
    public float timeSpentOnButtonGame;
    public int buttonGamePoints;
    public float buttonGameCooldown;
    public int buttonGameSceneIndex = 4;
    public bool firstTimeVideoScene = true;
    public bool firstTimeMessageScene = true;
    public bool skipInfoScreen = false;
    public int previousScene;
    public bool buttonNotificationReady = false;
    public bool messageNotificationReady = false;
    public float messageNotificationCooldown = 25;
    public bool doNotSwipe;
    public Sprite[] messageReactions = new Sprite[6];
    public int amountOfMessagesReceived;
    private void Awake()
    {
        if (gameController != null)
        {
            Destroy(this);
            return;
        }
        gameController = this;
        DontDestroyOnLoad(this);
        time = timerMinutes + ":" + timer10Seconds + (int)timerSeconds;
    }

    private void Update()
    {
        if (timerActive)
        {
            timerSeconds += Time.deltaTime;
            if (timerSeconds >= 10)
            {
                timerSeconds -= 10;
                timer10Seconds += 1;
                if (timer10Seconds == 6)
                {
                    timer10Seconds = 0;
                    timerMinutes += 1;
                    if (timerMinutes == 17)
                    {
                        OutOfTime();
                    }
                }
            }
            time = timerMinutes + ":" + timer10Seconds + (int)timerSeconds;
            if (canSwipe)
            {
                switch (SceneManager.GetActiveScene().buildIndex)
                {
                    case 1:
                    case 5:
                        timeSpentOnMath += Time.deltaTime;
                        break;
                    case 2:
                        timeSpentOnVideo += Time.deltaTime;
                        break;
                    case 3:
                        timeSpentOnMessages += Time.deltaTime;
                        break;
                    case 4:
                        timeSpentOnButtonGame += Time.deltaTime;
                        break;
                    default:
                        break;
                }
            }
            if (buttonGameCooldown > 0)
            {
                buttonGameCooldown -= Time.deltaTime;
                if (SceneManager.GetActiveScene().buildIndex == buttonGameSceneIndex && buttonGameCooldown >= 10)
                {
                    GameObject.Find("ButtonCooldownText").GetComponent<TextMeshProUGUI>().text = "00:" + (int)buttonGameCooldown;
                }
                else if (SceneManager.GetActiveScene().buildIndex == buttonGameSceneIndex && GameObject.Find("ButtonCooldownText").GetComponent<TextMeshProUGUI>().text != "00:00")
                {
                    GameObject.Find("ButtonCooldownText").GetComponent<TextMeshProUGUI>().text = "00:0" + (int)buttonGameCooldown;
                }
            }
            else if (SceneManager.GetActiveScene().buildIndex == buttonGameSceneIndex && GameObject.Find("ButtonCooldownText").GetComponent<TextMeshProUGUI>().text != "00:00")
            {
                GameObject.Find("ButtonCooldownText").GetComponent<TextMeshProUGUI>().text = "00:0" + (int)buttonGameCooldown;
            }

            if (messageNotificationReady && amountOfMessagesReceived < 5)
            {
                messageNotificationCooldown -= Time.deltaTime;
            }

            if (buttonGameCooldown <= 0 && buttonNotificationReady == true && NotificationManager.Instance != null)
            {
                if (previousScene != 4)
                {
                    ButtonNotification();
                }
            }
            if (messageNotificationCooldown <= 0 && messageNotificationReady == true && NotificationManager.Instance != null)
            {
                if (amountOfMessagesReceived < 5)
                {
                    messageNotificationCooldown = 25;
                    amountOfMessagesReceived++;
                    if (previousScene == 3)
                    {
                        MessageController.messageController.ActivateMessage(amountOfMessagesReceived);
                    }
                    else
                    {
                        MessageNotification();
                    }
                }
            }
        }
    }
    void OutOfTime()
    {
        SceneManager.LoadScene(7);
    }

    public void FirstTimeNotification()
    {
        NotificationManager.Instance.SetNewNotification("Se denne seje video!", 2);
        firstTimeInfoScene = false;
    }
    public void MessageNotification()
    {
        NotificationManager.Instance.SetNewNotification("Se denne nye besked!", 3);
    }
    public void ButtonNotification()
    {
        NotificationManager.Instance.SetNewNotification("Du kan få et point!", 4);
        buttonNotificationReady = false;
    }
}
