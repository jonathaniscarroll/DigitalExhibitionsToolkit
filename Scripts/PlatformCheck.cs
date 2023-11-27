using UnityEngine;
using UnityEngine.Events;

public class PlatformCheck : MonoBehaviour
{
	public RuntimePlatform chosenPlatform;
	public UnityEvent OnPlatform;

	void Start()
	{
		if (Application.platform == chosenPlatform)
		{
			Debug.Log("Running on chosen platform: " + chosenPlatform.ToString());
			OnPlatform.Invoke();
			// Insert your event or function call here
		}
	}
}