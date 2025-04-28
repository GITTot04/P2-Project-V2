using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;



public class NotificationManager : MonoBehaviour
{
    public static NotificationManager Instance 
    {
        get
        {
            if(instance != null)
            {
                return instance;
            }
            instance = FindFirstObjectByType<NotificationManager>();

            if(instance !=null)
            {
                return instance; 
            }

            CreateNewInstance(); 
            {
                return instance;
            }
        }
    } // public Singleton instance of the NotificationManager class that can be accessed from anywhere 

    public static NotificationManager CreateNewInstance() 
    {
        NotificationManager notificationManagerPrefab = Resources.Load<NotificationManager>("NotificationManager");
        instance = Instantiate(notificationManagerPrefab);
        return instance; // a public method to create a new instance of the NotificationManager class if one does not exist.
    }

   private static NotificationManager instance; //private Singleton instance to ensure the public singleton exists and Instance gets instance when refered. 

   private void Awake()
   {
        if (Instance != this)
        {
            Destroy(gameObject);
        }
   }
    
    [SerializeField] private Button notificationButton; //Serializefield to allow the button to be set in the inspector and display the notififcation.
    [SerializeField] private TextMeshProUGUI notificationText; //to display a text inside the button
    [SerializeField] private float fadeTime; //to set the time it takes to fade out the notification on inspector
    [SerializeField] private float slideDuration = 1f; // Duration of the slide animation
    [SerializeField] private Vector2 offScreenPosition = new Vector2(0, 6); //position off-scrren (above the screen)
    [SerializeField] private Vector2 onScreenPosition = new Vector2(0, 5); //Final position on screen

    private IEnumerator notificationCoroutine; //private IEnumerator to allow the notification to be displayed for a set amount of time. 
    public void SetNewNotification(string message, int sceneIndex)
    {
        if(notificationCoroutine != null) //This will be true when a notifaction is currently fading out, so when it's active.
        {
            StopCoroutine(notificationCoroutine); //This will stop the current nofication from fading out if it's not null.
        }

        notificationButton.onClick.RemoveAllListeners(); //This will clear all the pervious listeners 
        if (sceneIndex < SceneManager.GetActiveScene().buildIndex)
        {
            notificationButton.onClick.AddListener(() => GameObject.Find("SceneObjects").GetComponent<Swiping>().SwipeRight(sceneIndex));
        }
        else if (sceneIndex > SceneManager.GetActiveScene().buildIndex)
        {
            notificationButton.onClick.AddListener(() => GameObject.Find("SceneObjects").GetComponent<Swiping>().SwipeLeft(sceneIndex));
        }
        else
        {
            notificationButton.onClick.AddListener(() => SceneManager.LoadScene(sceneIndex));
            GameControllerScript.gameController.doNotSwipe = true;
        }

        notificationText.text = message; //set the the button text
        notificationButton.gameObject.SetActive(true); //Show the button

        //Start the slide-in animation
        StartCoroutine(SlideInNotification());

        notificationCoroutine = FadeOutNotification(); 
        StartCoroutine(notificationCoroutine); //This will start the coroutine to display the notification. 
    }

        private IEnumerator SlideInNotification() 
    {
        RectTransform rectTransform = notificationButton.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = offScreenPosition; // off-screen position
        float elapsedTime = 0f;
        while (elapsedTime < slideDuration)
        {
            elapsedTime += Time.unscaledDeltaTime;
            rectTransform.anchoredPosition = Vector2.Lerp(offScreenPosition, onScreenPosition, elapsedTime / slideDuration);
            yield return null;
        }

        rectTransform.anchoredPosition = onScreenPosition; //To ensure it ends at the final position
    }

    private IEnumerator FadeOutNotification() 
    {   
        float t = 0;
        Color initialColor = notificationButton.image.color;

        while(t < fadeTime)
        {
            t += Time.unscaledDeltaTime;
            float alpha = Mathf.Lerp(1f, 0f, t / fadeTime); 
            notificationButton.image.color = new Color(initialColor.r, initialColor.g, initialColor.b, alpha);
            notificationText.color = new Color(
                notificationText.color.r, 
                notificationText.color.g, 
                notificationText.color.b,
                alpha); 
            yield return null; 
        }
        notificationButton.gameObject.SetActive(false);
    }
}
