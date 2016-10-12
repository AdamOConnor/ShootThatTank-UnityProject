using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	
	public Text timerText;
	public int timeForlevel = 20;
	private CountdownTimer countdowntimer;
	private Player gamePlayer;
	
	// Use this for initialization#
	
	void Start() {
		countdowntimer = GetComponent<CountdownTimer>();
		countdowntimer.ResetTimer(timeForlevel);
	}

	//-------------------------------------------------------
	// Update is called once per frame
	void Update () {
		int secoundsLeft = countdowntimer.GetSecondsRemaining ();
		UpdateTimerDisplay(secoundsLeft);
		CheckGameOver(secoundsLeft);
	}
	
	//-------------------------------------------------------
	public void UpdateTimerDisplay(int secoundsLeft) {
		string timerMessage = "Time left = " + secoundsLeft;
		timerText.text = timerMessage;
		
	}	
	//--------------------------------------------------------
	
	private void CheckGameOver(int secoundsLeft) {
		if (secoundsLeft < 1) {
			Application.LoadLevel("scene_level03_GameOver");
		}
	}
	
	//--------------------------------------------------------
	
	
}

