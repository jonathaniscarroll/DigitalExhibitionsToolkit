using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.Events;

public class ScrollRectVideoController : MonoBehaviour
{
	public ScrollRect scrollRect;        // The ScrollRect containing the videos
	public VideoPlayer videoPlayer;      // The VideoPlayer component
	public RectTransform videoPlayerRect; // RectTransform of the VideoPlayer
	public UnityEvent OnVisible;

	private bool isPlaying = false;      // Keeps track of the video playing state
	private bool isPrepared;
	private bool isPreparing;

	void Start()
	{
		CheckVisibilityAndPlayVideo(); // Check visibility on start
	}

	void Update()
	{
		CheckVisibilityAndPlayVideo();
	}

	private void CheckVisibilityAndPlayVideo()
	{
		// Check if the VideoPlayer is within the visible area of the ScrollRect
		bool isVisible = RectTransformUtility.RectangleContainsScreenPoint(
			scrollRect.viewport, 
			videoPlayerRect.position, 
			null);

		// Play or pause the video based on its visibility
		if (isVisible && !isPlaying)
		{
			if(!isPreparing){
				videoPlayer.Prepare();
				isPreparing = true;
				videoPlayer.prepareCompleted += OnVideoPrepared;
				return;
			}
			if(isPrepared){
				videoPlayer.Play();
				isPlaying = true;
				OnVisible.Invoke();
			}
			
		}
		else if (!isVisible && isPlaying)
		{
			videoPlayer.Pause();
			isPlaying = false;
		}
	}
	
	void OnVideoPrepared(VideoPlayer vp){
		isPrepared = true;
	}
}
