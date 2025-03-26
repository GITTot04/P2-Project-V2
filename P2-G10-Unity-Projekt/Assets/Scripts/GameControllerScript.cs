using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
    public static GameControllerScript gameController;
    public bool swipeDirection;
    public bool canSwipe = true;
    public bool firstTimeInfoScreen = true;
    public bool timerActive;
    int timerMinutes = 12;
    int timer10Seconds;
    float timerSeconds;
    public string time;

    private void Awake()
    {
        if (gameController != null)
        {
            Destroy(this);
        }
        gameController = this;
        DontDestroyOnLoad(this);
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
                        timerActive = false;
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
