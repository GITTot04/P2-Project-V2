using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    int amountOfVideoClips = 4;
    int currentVideo;
    private void Start()
    {
        GetComponent<VideoPlayer>().loopPointReached += LoadNextVideo;
    }
    public void LoadRandomVideo()
    {
        currentVideo = Random.Range(1, amountOfVideoClips + 1);
        GetComponent<VideoPlayer>().clip = Resources.Load<VideoClip>("Clips/Clip" + currentVideo);
    }
    
    public void LoadNextVideo(VideoPlayer videoPlayer)
    {
        if (currentVideo == amountOfVideoClips)
        {
            currentVideo = 1;
        }
        else
        {
            currentVideo++;
        }
        videoPlayer.clip = Resources.Load<VideoClip>("Clips/Clip" + currentVideo);
    }
}
