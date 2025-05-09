using UnityEngine;
using UnityEngine.Video;

public class Comments : MonoBehaviour
{
    [SerializeField] GameObject commentPanel;
    [SerializeField] GameObject videoPlayer;
    public void OpenCommentPanel()
    {
        videoPlayer.GetComponent<VideoPlayer>().Pause();
        commentPanel.SetActive(true);
    }

    public void CloseCommentPanel()
    {
        videoPlayer.GetComponent<VideoPlayer>().Play();
        commentPanel.SetActive(false);
    }
}
