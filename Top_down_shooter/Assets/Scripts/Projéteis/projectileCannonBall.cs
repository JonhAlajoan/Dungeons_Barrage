﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileCannonBall : MonoBehaviour {

	float speed;
    float count;
	Rigidbody rb;
	void OnEnable()
    {
		rb = GetComponent<Rigidbody>();
		
		//speed = Random.Range (6f, 10f);
        //SetSpeed(speed);

	}

    private void OnDisable()
    {
        speed = Random.Range(6f, 10f);
        SetSpeed(speed);
    }

    public void SetSpeed(float newSpeed)
    {
		speed = newSpeed;
	}

	void Update ()
    {
       /* count += 1 * Time.deltaTime;
        if (count >= 1.5f)
        {
            while (speed >= 0)
            {
                speed -= 2f;
            }
            speed = 0.1f;
        }

		float moveDistance = speed * Time.deltaTime;
		transform.Translate (Vector3.up * moveDistance);
	*/
	if(Input.GetKeyDown(KeyCode.G))
		{
			rb.AddForce(new Vector3(0, 0, -10));
		}
	}
}
