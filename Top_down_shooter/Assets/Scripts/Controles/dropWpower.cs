using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropWpower : MonoBehaviour {

	public LayerMask collisionMask;
	public Transform Enemy_Hit_vfx;
	float skinWidth = 15f;
	Collider startCollider;
	public float radius = 300f;
    GameObject Manager;

    void Start ()
    {
		Collider[] initialCollisions = Physics.OverlapSphere (transform.position, radius,collisionMask);
        Manager = GameObject.FindWithTag("Manager");
    }


	void OnTriggerEnter(Collider c)
	{
        ClassesPlayer collision = c.GetComponent<ClassesPlayer>();

        if (collision != null)
        {
            collision.increaseWPower();
            Transform newVfx = Instantiate(Enemy_Hit_vfx, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
