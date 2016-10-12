using UnityEngine;
using System.Collections;

public class MineExplosion : MonoBehaviour {

	public ParticleEmitter mineExplosion; // particale
	public AudioClip explosionSound; // sound
//-------------------------------------------------------
	void OnTriggerEnter(Collider hit)
	{
		if (hit.CompareTag ("Player")) 
		{
			mineExplosion.emit = true; // emit particale
			audio.PlayOneShot(explosionSound); // play sound
		}
		else
		{
			mineExplosion.emit = false; // dont emit particale
		}
	}	
}
