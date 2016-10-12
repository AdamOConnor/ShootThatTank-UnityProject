using UnityEngine;
using System.Collections;

public class EnemyFireProjectile : MonoBehaviour {

	public float playerDistance;
	public Transform player;
	
	public AudioClip fireSound;
	public AudioClip reloadSound;
	
	const float FIRE_DELAY = 1.25f;// fire time
	public Rigidbody projectilePrefab; // prefab
	public float projectileSpeed = 500f; // speed of projectile
	
	private float nextFireTime = 0f;
	private const float MIN_Y = -1;
//--------------------------------------------------------------------
	private void Update () {
		playerDistance = Vector3.Distance (player.position, transform.position);
		if (playerDistance < 6f) 
		{
			if (Time.time > nextFireTime) // after time allow enemy to fire again
			{
				attack ();
			}
		}
	}
//--------------------------------------------------------------------
	void attack() {
		CreateProjectile(); // create prefab
		nextFireTime = Time.time + FIRE_DELAY; // fire next object
		audio.PlayOneShot(fireSound);
		audio.PlayOneShot(reloadSound);
	}
//--------------------------------------------------------------------
	private void CreateProjectile() {
		Vector3 position = transform.position;
		Quaternion rotation = transform.rotation;
		
		Rigidbody projectileRigidBody = (Rigidbody)Instantiate (projectilePrefab, position, rotation);
		
		Vector3 projectileVelocity = transform.TransformDirection (Vector3.forward * projectileSpeed);
		
		projectileRigidBody.AddForce (projectileVelocity);
		
		GameObject projectileGO = projectileRigidBody.gameObject;
		Destroy (projectileGO, 1.5f); // destroy projectile after time.
	}
	
}