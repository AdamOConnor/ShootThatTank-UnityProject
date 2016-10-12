using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public AudioClip intelSound;
	
	private PlayerDisplay playerdisplay; // display
	private int intel = 0; // intel 
	private float fillAmount = 1f; // fillAmount
	private int numFoodObjects; // number of objects

	public float delayBetweenHealth = 1; // delay between death
	public float nextTimeAllowedToLooseHealth = 0;
	public GameObject doorMessage; 
	public GameObject startMessage;
	public GameObject collectIntelMessage;
	public GameObject optionMessage;	

	// Use this for initialization
	void Start () {
		numFoodObjects = CountObjectsWithTag("Intel");
		playerdisplay = GetComponent<PlayerDisplay>();
		playerdisplay.UpdateScoreText(intel, numFoodObjects);
		playerdisplay.UpdateHealth(fillAmount);
	}
	
	// Update is called once per frame
	void Update () {
		playerdisplay.UpdateHealth(fillAmount);
	}
//-----------------------------------------------------------------
	private void LoseLife()
	{
		fillAmount = fillAmount - 0.35f;
		playerdisplay.UpdateHealth(fillAmount);
		if (Application.loadedLevel == 4) {
			if (fillAmount < 0f) {
				Application.LoadLevel("scene_level01_GameOver");
			}
		}
		if (Application.loadedLevel == 5) {
			if (fillAmount < 0f) {
				Application.LoadLevel ("scene_level02_GameOver");
			}
		}
		if (Application.loadedLevel == 6) {
			if (fillAmount < 0f) {
				Application.LoadLevel ("scene_level03_GameOver");
			}
		}
	}
//-----------------------------------------------------------
	private void LoseLifeWater()
	{
		fillAmount = fillAmount - 0.1f;
		playerdisplay.UpdateHealth(fillAmount);
		if (Application.loadedLevel == 4) {
			if (fillAmount < 0f) {
				Application.LoadLevel ("scene_level01_GameOver");
			}
		}
		if (Application.loadedLevel == 5) {
			if (fillAmount < 0f) {
				Application.LoadLevel ("scene_level02_GameOver");
			}
		}
		if (Application.loadedLevel == 6) {
			if (fillAmount < 0f) {
				Application.LoadLevel ("scene_level03_GameOver");
			}
		}
	}
//------------------------------------------------------------
	void OnTriggerEnter(Collider hit)
	{	
		if (hit.CompareTag ("Intel")) {
			intel++;
			playerdisplay.UpdateScoreText(intel,numFoodObjects);
			Destroy(hit.gameObject);
			audio.PlayOneShot(intelSound);
		}
		if (hit.CompareTag ("intelSensor")) {
			CheckGameWon();		
		}
		if (hit.CompareTag ("Mine")) {
			LoseLife();
			Destroy(hit.gameObject,2.5f);
		}
		if (hit.CompareTag ("EnemyBullet")) {
			LoseLife();
		}
		if (hit.CompareTag ("SeaCollider")) {
			Application.LoadLevel("scene_level03_GameOver");
		}
		if(hit.CompareTag ("GarageDoor") & CountObjectsWithTag("Intel") > 1 )
		{
			Instantiate(doorMessage);
		}
		if(hit.CompareTag("StartSensor")) {
			Instantiate(startMessage);
		}
		if(hit.CompareTag("CollectSensor")) {
			Instantiate(collectIntelMessage);
		}
		if(hit.CompareTag("EnemySensor")) {
			Instantiate(optionMessage);
		}
	}
//------------------------------------------------------------
	void OnTriggerStay(Collider hit) {
		if(hit.CompareTag ("WaterCollider")) {
			if (Time.time > nextTimeAllowedToLooseHealth) {
				LoseLifeWater();	
				// delay between death
				nextTimeAllowedToLooseHealth = Time.time + delayBetweenHealth;
			}
		}
	}
//-------------------------------------------------------------
	public int CountObjectsWithTag(string tag)
	{
		GameObject[] foodObjects = GameObject.FindGameObjectsWithTag(tag); // count objects
		return foodObjects.Length;
	}
	
//--------------------------------------------------------------
	private void CheckGameWon()
	{
		numFoodObjects = CountObjectsWithTag("Intel");
		if(Application.loadedLevel == 4) {
			if(numFoodObjects < 1)
			{
				Application.LoadLevel("scene_level01_GameWon");
			}
		}
		if (Application.loadedLevel == 5) {
			if(numFoodObjects < 1)
			{
				Application.LoadLevel("scene_level02_GameWon");
			}
		}
		if (Application.loadedLevel == 6) {
			if(numFoodObjects < 1)
			{
				Application.LoadLevel("scene_level03_GameWon");
			}
		}
	}

}
