using UnityEngine;

public class TimeOutput : MonoBehaviour
{
	public FloatEvent OutputTime;
	public StringEvent OutputTimeFormatted;
	public void Output()
	{
		// Get the current system time
		System.DateTime currentTime = System.DateTime.Now;

		// Calculate the total minutes elapsed since midnight
		float totalMinutes = (float)(currentTime.Hour * 60 + currentTime.Minute);

		// Calculate the percentage of the day passed (0% at midnight, 100% at 11:59 PM)
		float percentageOfDay = totalMinutes / (24 * 60) * 100;

		// Output the percentage to the console
		//Debug.Log("Percentage of day passed: " + percentageOfDay.ToString("F2"));
		OutputTime.Invoke(percentageOfDay);
		OutputTimeFormatted.Invoke(currentTime.ToString("HH:mm"));
	}
}
