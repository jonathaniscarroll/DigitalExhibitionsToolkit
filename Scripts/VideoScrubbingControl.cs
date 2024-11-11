using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoScrubbingControl : MonoBehaviour
{
	public Slider slider;
	public VideoPlayer videoPlayer;
	//public Text timeText; // Reference to a Text component to display the time
	public StringEvent OutputTimeString;

	[field:SerializeField]
	public bool isScrubbing{get;set;} // Flag to indicate if the Slider is being scrubbed manually

	void Start()
	{
		slider.onValueChanged.AddListener(OnSliderValueChanged);
		videoPlayer.loopPointReached += OnVideoEnd; // Optional: Handle end of video
	}

	void Update()
	{
		if (!isScrubbing)
		{
			UpdateSliderPosition();
			UpdateTimeText();
		}
	}

	void OnSliderValueChanged(float value)
	{
		//isScrubbing=true;
		float videoTime = value * (float)videoPlayer.length;
		videoPlayer.time = videoTime;
	}

	void UpdateSliderPosition()
	{
		if (videoPlayer.isPlaying)
		{
			slider.SetValueWithoutNotify((float)videoPlayer.time / (float)videoPlayer.length);
		}
	}

	void UpdateTimeText()
	{
		int minutes = Mathf.FloorToInt((float)videoPlayer.time / 60);
		int seconds = Mathf.FloorToInt((float)videoPlayer.time % 60);

		OutputTimeString.Invoke(string.Format("{0:00}:{1:00}", minutes, seconds));
	}

	void OnVideoEnd(VideoPlayer source)
	{
		// Optional: Handle end of video (e.g., stop playback or loop)
		Debug.Log("Video playback ended.");
	}
}
