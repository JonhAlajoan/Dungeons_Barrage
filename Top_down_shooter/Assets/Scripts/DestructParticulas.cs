using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructParticulas : MonoBehaviour {

	public ParticleSystem particleSys;

	// Update is called once per frame
	void Update () {
		if(particleSys)
		{
			if(!particleSys.IsAlive())
			{
                TrashMan.despawn(gameObject);
			}
		}
	}
}
