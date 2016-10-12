using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour {

	public AudioClip enemyDeathSound;// sound death from enemy
//-----------------------------------------------
	void OnTriggerEnter(Collider hit)
	{
		if (hit.CompareTag ("Enemy")) {

			audio.PlayOneShot(enemyDeathSound); // sound enemyDeathSound
			Destroy(hit.gameObject,1.5f); // destroy enemyTank

		}
	}
}
