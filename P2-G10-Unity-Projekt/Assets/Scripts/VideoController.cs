using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    [SerializeField] VideoClip[] videoClips = new VideoClip[4];
    int currentVideo;
    public void LoadRandomVideo()
    {
        currentVideo = Random.Range(1, videoClips.Length + 1);
        GetComponent<VideoPlayer>().clip = Resources.Load<VideoClip>("Clips/Clip" + currentVideo);
    }
    public void LoadNextVideo()
    {
        if (currentVideo == 4)
        {
            currentVideo = 1;
        }
        else
        {
            currentVideo++;
        }
        GetComponent<VideoPlayer>().clip = Resources.Load<VideoClip>("Clips/Clip" + currentVideo);
    }
}
