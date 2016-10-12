using UnityEngine;
using System.Collections;

public class DoorSensor : MonoBehaviour {
	private Player player;
	private Animator animator;
		
	void Start(){
		animator = GetComponent<Animator>();
		GameObject playerGO = GameObject.FindGameObjectWithTag ("Player");
		player = playerGO.GetComponent<Player> ();
	}
//--------------------------------------------------------------------
	void Update() {
		player.CountObjectsWithTag(tag);
	}
//--------------------------------------------------------------------	
	void OnTriggerEnter(Collider hit){
		int playerObjects = player.CountObjectsWithTag ("Intel");
		if (hit.CompareTag ("Player") && playerObjects < 1) { // when player has enterd collider and intel is all collected
			animator.SetTrigger ("Open");
		}
	}
//--------------------------------------------------------------------
	void OnTriggerExit(Collider hit){
		int playerObjects = player.CountObjectsWithTag ("Intel");
		if(hit.CompareTag("Player") && playerObjects < 1){ // when player has left collider and intel is all collected
			animator.SetTrigger("Closed");
		}
	}

}

