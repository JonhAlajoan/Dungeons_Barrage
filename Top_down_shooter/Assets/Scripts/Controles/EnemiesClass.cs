using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesClass : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	

    public virtual void randomDropWPower(int minimum, int maximum)
    {
        int numRandom = Random.Range(minimum, (maximum + 1));
        if (numRandom == 1)
        {
           // GameObject newWpowerPickup = Instantiate(dropWPower, new Vector3(gameObject.transform.position.x, 2.45f, gameObject.transform.position.z), gameObject.transform.rotation);
        }
    }

    public virtual void randomDropBomb()
    {

    }
	// Update is called once per frame
	void Update () {
		
	}
}
