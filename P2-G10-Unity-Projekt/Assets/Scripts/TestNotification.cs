using UnityEngine;

public class TestNotification : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NotificationManager.Instance.SetNewNotification("This is a test notification", 2); 
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > 5f)
        {
            NotificationManager.Instance.SetNewNotification("Hey this is the second test notification <3", 3);
            Destroy(this);
        }        
    }
}
