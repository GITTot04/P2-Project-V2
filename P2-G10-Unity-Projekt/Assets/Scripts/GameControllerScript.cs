using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
    public static GameControllerScript gameController;
    public bool swipeDirection;
    public bool canSwipe = true;
    public bool firstTimeInfoScreen = true;
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
        }
    }
    // Ændre 0 til "You Lost" skærmens index
    void OutOfTime()
    {
        SceneManager.LoadScene(0);
    }
}
