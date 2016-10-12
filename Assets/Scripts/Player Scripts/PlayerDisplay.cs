using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class PlayerDisplay : MonoBehaviour {

	public Text scoreText;
	public Image healthBar;
	private Player player;
//-------------------------------------------------
	public void UpdateScoreText(int newIntel,int numFoodObjects)
	{
		string scoreMessage = "Intel = "+newIntel+" / " + numFoodObjects;// show intel collected and intel needed to be collected
		scoreText.text = scoreMessage;
	}
//--------------------------------------------------
	public void UpdateHealth(float fillAmount) {
		healthBar.fillAmount = fillAmount; // show healthbar.
	}
}
