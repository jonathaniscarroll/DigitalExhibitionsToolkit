using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.Events;

public class DeviceDetector : MonoBehaviour
{
	public UnityEvent IsMobile;
	public UnityEvent IsDesktop;

	public void Detect()
	{
		if (isMobileDevice())
		{
			Debug.Log("Running on a mobile device.");
			IsMobile.Invoke();
		}
		else
		{
			Debug.Log("Running on a desktop device.");
			IsDesktop.Invoke();
		}
	}
	
	private bool isMobileDevice(){
		return Application.platform == RuntimePlatform.WebGLPlayer && Application.isMobilePlatform;
	}
}
