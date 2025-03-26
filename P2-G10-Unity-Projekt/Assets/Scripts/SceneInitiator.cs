using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneInitiator : MonoBehaviour
{
    float timeSpentMoving;
    float timeToMove = 2;
    Vector3 startPos;
    Vector3 endPos = new Vector3(0, 0, 0);
    Vector3 currentPos;
    int currentActiveSceneIndex;
    private void Awake()
    {
        if (!GameControllerScript.gameController.firstTimeInfoScreen)
        {
            if (GameControllerScript.gameController.swipeDirection == true)
            {
                transform.position = new Vector3(-5, 0, 0);
            }
            if (GameControllerScript.gameController.swipeDirection == false)
            {
                transform.position = new Vector3(5, 0, 0);
            }
        }
        else
        {
            GameControllerScript.gameController.firstTimeInfoScreen = false;
        }
        startPos = transform.position;
        currentPos = startPos;
    }
    private void Start()
    {
        if (SceneManager.sceneCount == 1)
        {
            currentActiveSceneIndex = 0;
        }
        else
        {
            currentActiveSceneIndex = 1;
        }
        GameControllerScript.gameController.timerActive = true;
    }

    private void Update()
    {
        if (timeSpentMoving < timeToMove && currentPos != endPos)
        {
            timeSpentMoving += Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, endPos, timeSpentMoving/timeToMove);
            currentPos = transform.position;
        }
        else if (SceneManager.sceneCount != 1)
        {
            if (SceneManager.GetSceneAt(currentActiveSceneIndex).name != SceneManager.GetSceneAt(0).name)
            {
                SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(0));
                currentActiveSceneIndex = 0;
                GameControllerScript.gameController.canSwipe = true;
            }
        }
    }
}