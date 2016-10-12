// file: MoveTowardsWaypoint.cs
using UnityEngine;
using System.Collections;

public class MoveTowardsWaypoint : MonoBehaviour {
	public const float ARRIVE_DISTANCE = 4f;
	public float speed = 6.0F;
	private GameObject targetGO;
	private WaypointManager waypointManager;

	public float playerDistance;
	public Transform player;
	public float rotationDamping;
	public float moveSpeed;
//***********************************************//
	
	private void Awake(){
		waypointManager = GetComponent<WaypointManager>(); // get waypoints
		targetGO = waypointManager.NextWaypoint(null);
	}
//--------------------------------------------------------------------
	private void Update () {
		playerDistance = Vector3.Distance (player.position, transform.position);
		
		if (playerDistance < 15f) 
		{
			lookAtPlayer (); // look at player
		} 
		if (playerDistance < 10f) 
		{
			if(playerDistance > 5f)
			{
				chase(); //chase the player within this distance
			}
		}
		else {
				transform.LookAt (targetGO.transform);
				float distance = speed * Time.deltaTime;
				Vector3 source = transform.position;
				Vector3 target = targetGO.transform.position;
				transform.position = Vector3.MoveTowards (source, target, distance);
			
				if (Vector3.Distance (source, target) < ARRIVE_DISTANCE)
				{
					targetGO = waypointManager.NextWaypoint (targetGO);
				}
			}
	}
//--------------------------------------------------------------------
	void lookAtPlayer() {
		Quaternion rotation = Quaternion.LookRotation (player.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * rotationDamping);
	}
//--------------------------------------------------------------------
	void chase() {
		transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);
	}

}
