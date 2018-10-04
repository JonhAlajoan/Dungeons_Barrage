using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runeKen : MonoBehaviour {



    public LayerMask collisionMask;
    float skinWidth = 15f;
    Collider startCollider;
    public float radius = 300f;
    void Start()
    {
        Collider[] initialCollisions = Physics.OverlapSphere(transform.position, radius, collisionMask);
    }

    IEnumerator destroyAfterdelay()
    {
        yield return new WaitForSeconds(1f);
        TrashMan.despawn(gameObject);
    }

    void OnTriggerEnter(Collider c)
    {
        ShamanController playerContr = c.GetComponent<ShamanController>();
        if(playerContr !=null)
        {
            playerContr.typeOfRuneBeingUsed = 1;
            playerContr.changeTypeOfForm();
            StartCoroutine(destroyAfterdelay());
        }
        
    }
}
