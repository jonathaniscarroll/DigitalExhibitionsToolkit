using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Collections.Generic;

public class VideoController : MonoBehaviour
{
	public VideoPlayer videoPlayer;
	public List<float> timePoints;
	public StringEvent currentTimeText;

	public int currentIndex = 0;

	private void Start()
	{
		UpdateTimeText();
	}
	
	void LateUpdate(){
		if(videoPlayer.time>timePoints[currentIndex+1]){
			currentIndex++;
		}
		currentTimeText.Invoke($"Current Time: {videoPlayer.time:F2}s");
	}

	public void PreviousTimePoint()
	{
		if (currentIndex > 0)
		{
			currentIndex--;
			JumpToTimePoint(currentIndex);
		}
	}

	public void NextTimePoint()
	{
		if (currentIndex < timePoints.Count - 1)
		{
			currentIndex++;
			JumpToTimePoint(currentIndex);
		}
	}

	private void JumpToTimePoint(int index)
	{
		if (videoPlayer != null && index >= 0 && index < timePoints.Count)
		{
			videoPlayer.time = timePoints[index];
			UpdateTimeText();
		}
	}

	private void UpdateTimeText()
	{
		if (currentTimeText != null)
		{
			currentTimeText.Invoke($"Current Time: {videoPlayer.time:F2}s");
		}
	}
}
