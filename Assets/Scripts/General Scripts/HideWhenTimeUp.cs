using UnityEngine;
using System.Collections;

public class HideWhenTimeUp : MonoBehaviour {

	private CountdownTimer myTimer;
	private int delayUntilHide = 3;

	private void Start()
	{
		myTimer = GetComponent<CountdownTimer>();
		myTimer.ResetTimer(delayUntilHide); // reset timer
	}
//-------------------------------------------------------
	private void Update()
	{
		if(myTimer.GetSecondsRemaining() < 0)
		{
			Destroy(gameObject); // destroy object when seconds are 0 
		}
	}

}
