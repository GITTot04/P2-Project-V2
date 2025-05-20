using UnityEngine;

public class ReactionButton : MonoBehaviour
{
    [SerializeField] GameObject emojiPanel;
    public void OpenOrCloseEmojiPanel()
    {
        emojiPanel.SetActive(!emojiPanel.activeSelf);
    }
}
