using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoPlayerController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string nextSceneName;

    private void Start()
    {
        // Ensure the VideoPlayer is set to not play on awake
        videoPlayer.playOnAwake = false;

        // Hook up the videoPlayer's prepareCompleted event
        videoPlayer.prepareCompleted += OnVideoPrepared;

        // Start preparing the video
        videoPlayer.Prepare();
    }

    private void OnVideoPrepared(VideoPlayer source)
    {
        // Unsubscribe from the event to avoid multiple calls
        source.prepareCompleted -= OnVideoPrepared;

        // Display the video on the canvas with the "Stretch" aspect ratio
        RawImage rawImage = GetComponent<RawImage>();
        rawImage.texture = videoPlayer.texture;

        // Add a listener to the videoPlayer's loopPointReached event
        videoPlayer.loopPointReached += OnVideoEnd;

        // Play the video as soon as it's prepared
        videoPlayer.Play();
    }

    private void OnVideoEnd(VideoPlayer source)
    {
        // Load the next scene when the video ends
        SceneManager.LoadScene(nextSceneName);
    }
}

