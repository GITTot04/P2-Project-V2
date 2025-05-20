using UnityEngine;

public class MessageController : MonoBehaviour
{
    public static MessageController messageController;
    public GameObject[] messages = new GameObject[6];
    private void Awake()
    {
        messageController = this;
    }

    public void ActivateMessage(int messageNumber)
    {
        messages[messageNumber].SetActive(true);
    }
}
