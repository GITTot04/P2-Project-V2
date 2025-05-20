using UnityEngine;
using UnityEngine.UI;

public class EmojiButton : MonoBehaviour
{
    [SerializeField] GameObject reactionButton;
    [SerializeField] GameObject emojiPanel;
    public void ApplyEmoji(int messageNumber)
    {
        reactionButton.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
        switch (messageNumber)
        {
            case 1:
                GameControllerScript.gameController.messageReactions[0] = GetComponent<Image>().sprite;
                break;
            case 2:
                GameControllerScript.gameController.messageReactions[1] = GetComponent<Image>().sprite;
                break;
            case 3:
                GameControllerScript.gameController.messageReactions[2] = GetComponent<Image>().sprite;
                break;
            case 4:
                GameControllerScript.gameController.messageReactions[3] = GetComponent<Image>().sprite;
                break;
            case 5:
                GameControllerScript.gameController.messageReactions[4] = GetComponent<Image>().sprite;
                break;
            case 6:
                GameControllerScript.gameController.messageReactions[5] = GetComponent<Image>().sprite;
                break;
            default:
                break;
        }
        emojiPanel.SetActive(false);
    }
}
