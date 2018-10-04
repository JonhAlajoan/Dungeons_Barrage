using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	public Transform muzzle;
    float count;
    private void OnEnable()
    {
        count = 1 * Time.deltaTime;
        StartCoroutine(SpawnFlame());
    }

    IEnumerator SpawnFlame()
    {
        yield return new WaitForSeconds(0.3f);
        TrashMan.spawn("FireBeforeTurret", muzzle.transform.position, muzzle.transform.rotation);
    }

    private void Update()
    {
        
        count += 1 * Time.deltaTime;
        if(count > 9)
        {
            TrashMan.despawn(gameObject);
            count = 0;
        }
    }


}
