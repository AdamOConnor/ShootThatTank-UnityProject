using UnityEngine;
using System.Collections;

public class PlayerTankDisable : MonoBehaviour {

	public ParticleEmitter playerSmoke; // smoke partical
//--------------------------------------------------------------------
	void OnTriggerEnter(Collider hit)
	{
		if (hit.CompareTag ("EnemyBullet")) 
		{
			playerSmoke.emit = true; // emit smoke when enemy has hit player
		}
		else 
			if (hit.CompareTag ("Mine")) 
			{
				playerSmoke.emit = true; // emit smoke when mine hit
			}
		else
		{
			playerSmoke.emit = false;
		}
	}
}