using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Events;

public class VideoPreparer : MonoBehaviour
{
	public VideoPlayer videoPlayer;
	public UnityEvent OnPrepare;
	public void Prepare(){
		videoPlayer.prepareCompleted += Preparing;
		videoPlayer.Prepare();
	}
	
	private void Preparing(VideoPlayer vp){
		OnPrepare.Invoke();
	}
}
