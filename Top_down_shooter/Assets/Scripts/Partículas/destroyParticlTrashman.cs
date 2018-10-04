using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyParticlTrashman : MonoBehaviour {
	public ParticleSystem particleSys;
	void Update () {
		if(particleSys)
		{
			if(!particleSys.IsAlive())
			{
				TrashMan.despawn (gameObject);
			}
		}
	}
}
