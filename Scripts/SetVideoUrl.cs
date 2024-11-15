using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SetVideoUrl : MonoBehaviour
{
	[SerializeField]
	private string _videoUrl;
	public string videoUrl{
		get{return _videoUrl;}
		set{
			_videoUrl = value;
			ChangeVideoUrl(_videoUrl);
		}
	}
	
	public VideoPlayer videoPlayer;
	
	void Start()
	{
		
		videoPlayer.prepareCompleted += OnPrepareCompleted;
		ChangeVideoUrl(videoUrl);
	}

	void OnPrepareCompleted(VideoPlayer vp)
	{
		videoPlayer.Play();
	}

	public void ChangeVideoUrl(string newUrl)
	{
		videoPlayer.Stop();
		videoPlayer.url = newUrl;
		videoPlayer.Prepare();
	}
}
