using UnityEngine;
using UnityEngine.SceneManagement;

public class Swiping : MonoBehaviour
{
    Vector2 startTouchPos;
    Vector2 endTouchPos;
    public int swipeLeftBuildIndex;
    public int swipeRightBuildIndex;

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPos = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPos = Input.GetTouch(0).position;
            if (endTouchPos.x > startTouchPos.x)
            {
                SwipeLeft(swipeLeftBuildIndex);
            }
            if (endTouchPos.x < startTouchPos.x)
            {
                SwipeRight(swipeRightBuildIndex);
            }
        }
    }

    void SwipeLeft(int buildIndex)
    {
        if (GameControllerScript.gameController.canSwipe == true && buildIndex != 5)
        {
            transform.position = new Vector3(0, 0, 10);
            GameControllerScript.gameController.swipeDirection = true;
            GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled = false;
            if (GameObject.Find("EventSystem") != null)
            {
                GameObject.Find("EventSystem").SetActive(false);
            }
            SceneManager.LoadScene(buildIndex, LoadSceneMode.Additive);
            GameControllerScript.gameController.canSwipe = false;
        }
    }

    void SwipeRight(int buildIndex)
    {
        if (GameControllerScript.gameController.canSwipe == true && buildIndex != 0)
        {
            transform.position = new Vector3(0, 0, 10);
            GameControllerScript.gameController.swipeDirection = false;
            GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled = false;
            if (GameObject.Find("EventSystem") != null)
            {
                GameObject.Find("EventSystem").SetActive(false);
            }
            SceneManager.LoadScene(buildIndex, LoadSceneMode.Additive);
            GameControllerScript.gameController.canSwipe = false;
        }
    }
}
