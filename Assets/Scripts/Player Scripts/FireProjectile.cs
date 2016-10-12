using UnityEngine;
using System.Collections;

public class FireProjectile : MonoBehaviour {

	public AudioClip fireSound;
	public AudioClip reloadSound;

	const float FIRE_DELAY = 1.25f;
	public Rigidbody projectilePrefab;
	public float projectileSpeed = 500f;

	private float nextFireTime = 0f;
	private const float MIN_Y = -1;

	// Update is called once per frame
	void Update () {
		if (Time.time > nextFireTime) { // after time fire projectile
			CheckFireKey (); // run CheckFireKey
		}
	}

	//-----------------------------------------------
	private void CheckFireKey() {

		if (Input.GetButton ("Fire1")) { // when leftclick or leftctrl fire projectile
			CreateProjectile();
			nextFireTime = Time.time + FIRE_DELAY;
			audio.PlayOneShot(fireSound); // fire sound 
			audio.PlayOneShot(reloadSound); // then reload
		}
	}

	//--------------------------------------------------
	private void CreateProjectile() {

		Vector3 position = transform.position;
		Quaternion rotation = transform.rotation;

		Rigidbody projectileRigidBody = 
			(Rigidbody)Instantiate (projectilePrefab, position, rotation);

		Vector3 projectileVelocity = transform.TransformDirection (Vector3.forward * projectileSpeed);

		projectileRigidBody.AddForce (projectileVelocity);

		GameObject projectileGO = projectileRigidBody.gameObject;
		Destroy (projectileGO, 1.5f); // destroy after certain time.

	}
}
