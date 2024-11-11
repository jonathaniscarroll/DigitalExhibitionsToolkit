using UnityEngine;
using UnityEngine.Video;

public class VideoFrameLoader : MonoBehaviour
{
	public VideoPlayer videoPlayer;
	public int FrameToLoad = 1;

	void Start()
	{
		// Make sure VideoPlayer component is attached
		if (videoPlayer == null)
		{
			Debug.LogError("VideoPlayer component is not attached!");
			return;
		}

		// Set the video clip
		//videoPlayer.clip = Resources.Load<VideoClip>("YourVideoClipName");

		// Prepare the video
		videoPlayer.Prepare();

		// Add a listener for when video is prepared
		videoPlayer.prepareCompleted += OnVideoPrepared;
	}

	void OnVideoPrepared(VideoPlayer vp)
	{
		// Display the first frame
		videoPlayer.frame = FrameToLoad;

		// Pause the video
		videoPlayer.Pause();

		// Remove the listener
		videoPlayer.prepareCompleted -= OnVideoPrepared;
	}
}
