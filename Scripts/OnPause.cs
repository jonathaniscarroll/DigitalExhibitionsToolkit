using UnityEngine;
using UnityEngine.Events;

public class OnPause : MonoBehaviour
{
	public UnityEvent OnPauseEvent;
	private void OnApplicationPause(bool pauseStatus)
	{
		if (pauseStatus)
		{
			// Code to execute when the application is paused
			OnPauseEvent.Invoke();
		}
	}

}
