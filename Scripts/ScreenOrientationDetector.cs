using UnityEngine;

public class ScreenOrientationDetector : MonoBehaviour
{
	public enum OrientationType
	{
		Portrait,
		Landscape
	}

	public OrientationType currentOrientation;
	public BoolEvent IsPortrait;
	
	void Update()
	{
		if (Screen.width != currentWidth || Screen.height != currentHeight)
		{
			Detect();
		}
	}

	private int currentWidth;
	private int currentHeight;


	public void Detect()
	{
		currentWidth = Screen.width;
		currentHeight = Screen.height;

		if (currentWidth > currentHeight)
		{
			currentOrientation = OrientationType.Landscape;
		}
		else
		{
			currentOrientation = OrientationType.Portrait;
		}

		Debug.Log("Current orientation: " + currentOrientation);
		IsPortrait.Invoke(currentOrientation==OrientationType.Portrait);
		
	}
}
