using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class totemASBuff : MonoBehaviour {
    GameObject playerObj;
    Collider colliderThis;
    EngineerController controllerPlayer;
    float count;
    
    private void Start()
    {
        playerObj = GameObject.FindWithTag("PlayerHP");
        colliderThis = GetComponent<Collider>();
        

        colliderThis.enabled = false;
        count = 1 * Time.deltaTime;
        
    }

    private void Update()
    {
        count += 1 * Time.deltaTime;
        if(count > 1)
        {
            colliderThis.enabled = true;
            count = 0;
        }
    }

    void OnTriggerEnter(Collider c)
    {
        controllerPlayer = c.GetComponent<EngineerController>();

        if (controllerPlayer!=null)
        {
            controllerPlayer.StartCoroutine("buffAttackSpeed");
            colliderThis.enabled = false;
        }
    }
}
