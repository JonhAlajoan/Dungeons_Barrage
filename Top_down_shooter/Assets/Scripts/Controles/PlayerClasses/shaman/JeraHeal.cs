using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeraHeal : MonoBehaviour {

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

    private void OnEnable()
    {
        StartCoroutine(CoroutineDeactivation());
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

    IEnumerator CoroutineDeactivation()
    {
        yield return new WaitForSeconds(10f);
        TrashMan.despawn(gameObject);
    }

    void OnTriggerEnter(Collider c)
    {
        LivingEntity objectCollided = c.GetComponent<LivingEntity>();
        if (objectCollided != null && c.gameObject.tag == "PlayerHP")
        {
            objectCollided.Heal(2);
            GameObject vfx = TrashMan.spawn("HealFx", c.transform.position, new Quaternion(0,0,0,0));
            vfx.transform.parent = c.gameObject.transform;
            colliderThis.enabled = false;
        }
        if (objectCollided != null && c.gameObject.tag != "PlayerHP")
        {
            objectCollided.TakeDamage(2f);
            TrashMan.spawn("Hit_Jera", c.transform.position, c.transform.rotation);
        }
    }
}
