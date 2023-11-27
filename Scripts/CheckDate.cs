using System;
using UnityEngine;

public class CheckDate : MonoBehaviour
{
	// Set these in the inspector
	public int targetYear = 2023;
	public int targetMonth = 12;
	public int targetDay = 31;
	
	public BoolEvent IsPassedTargetDate;

	public void Check()
	{
		// Create a DateTime from the specified year, month, and day
		DateTime targetDate = new DateTime(targetYear, targetMonth, targetDay);

		if (DateTime.Now > targetDate)
		{
			IsPassedTargetDate.Invoke(true);
			Debug.Log("The current date is after the target date.");
		}
		else
		{
			IsPassedTargetDate.Invoke(false);
			Debug.Log("The current date is before the target date.");
		}
	}
}
