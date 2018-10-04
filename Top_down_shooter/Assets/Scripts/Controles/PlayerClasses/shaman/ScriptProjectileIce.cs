using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptProjectileIce : MonoBehaviour {

    float damage = 50;
    Quaternion rotPlayer;

    private void Start()
    {
        rotPlayer = GameObject.FindWithTag("PlayerHP").GetComponent<Transform>().rotation;
    }
    private void OnTriggerEnter(Collider c)
    {
        Vector3 newPos = new Vector3(c.transform.position.x,c.transform.position.y + 5,c.transform.position.z);
        
        IDamageable damageableObject = c.GetComponent<IDamageable>();
        if (damageableObject != null && c.gameObject.tag != "PlayerHP")
        {
            damageableObject.TakeDamage(damage);

            TrashMan.spawn("Ice_Explosion", c.transform.position, new Quaternion(0,0,0,0));
            TrashMan.spawn("Ice_Wall", c.transform.position, rotPlayer);    
        }
        else
        {
        
            TrashMan.spawn("Ice_Explosion", gameObject.transform.position, new Quaternion(0, 0, 0, 0));
            TrashMan.spawn("Ice_Wall", gameObject.transform.position, rotPlayer);
        }
        TrashMan.despawn(gameObject);
    }
}
