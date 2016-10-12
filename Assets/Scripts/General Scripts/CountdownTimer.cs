using UnityEngine;
using System.Collections;

public class CountdownTimer : MonoBehaviour 
{
	private float countdownTimerStartTime; // start time
	private int countdownTimerDuration; // duration

	public int GetTotalSeconds()
	{
		return countdownTimerDuration;
	}
//--------------------------------------------------------------------
	public void ResetTimer(int seconds) // resetTimer
	{
		countdownTimerStartTime = Time.time;
		countdownTimerDuration = seconds;
	}
//--------------------------------------------------------------------
	public int GetSecondsRemaining() // get seconds remaining 
	{
		int elapsedSeconds = (int)(Time.time - countdownTimerStartTime);
		int secondsLeft = (countdownTimerDuration - elapsedSeconds);
		return secondsLeft;
	}
//--------------------------------------------------------------------
	public float GetProportionTimeRemaining()
	{
		float proportionLeft = (float)GetSecondsRemaining() / (float)GetTotalSeconds();
		return proportionLeft;
	}
}
