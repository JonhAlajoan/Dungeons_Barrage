using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healPriestScript : MonoBehaviour {

    GameObject playerObj;
    Collider colliderThis;
    PriestController controllerPlayer;
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
        if (count > 1)
        {
            colliderThis.enabled = true;
            count = 0;
        }
    }

    void OnTriggerEnter(Collider c)
    {
        controllerPlayer = c.GetComponent<PriestController>();

        if (controllerPlayer != null)
        {
            controllerPlayer.Heal(1);
            colliderThis.enabled = false;
        }
    }
}
