using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(Renderer), typeof(VideoPlayer))]
public class PauseVideoOnInvisible : MonoBehaviour
{
	private VideoPlayer videoPlayer;
	private Renderer objectRenderer;

	void Start()
	{
		videoPlayer = GetComponent<VideoPlayer>();
		objectRenderer = GetComponent<Renderer>();
	}

	void Update()
	{
		// If the camera can see the object
		if (objectRenderer.isVisible)
		{
			// If the video player is not playing, play it
			if (!videoPlayer.isPlaying)
			{
				videoPlayer.Play();
			}
		}
		else
		{
			// If the video player is playing, pause it
			if (videoPlayer.isPlaying)
			{
				Debug.Log("pausing");
				videoPlayer.Pause();
			}
		}
	}
}
