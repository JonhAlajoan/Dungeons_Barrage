using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheDamage : MonoBehaviour {

    float damage;
    string nameOfHit;

    private void Start()
    {
        if(gameObject.name == "Cube.109")
        {
            nameOfHit = "hit_Solar";
            damage = 3f;
        }

        if (gameObject.name == "Cube.106")
        {
            nameOfHit = "hit_Lunar";
            damage = 5f;
        }

        if (gameObject.name == "mixamorig:LeftFoot" || gameObject.name == "mixamorig:RightFoot" || gameObject.name == "mixamorig:RightForeArm" || gameObject.name == "mixamorig:LeftForeArm")
        {
            if(gameObject.tag == "Isa")
            {
                nameOfHit = "Hit_Isa";
                damage = 5f;
            }

            if (gameObject.tag == "Jera")
            {
                nameOfHit = "Hit_Jera";
                damage = 3f;
            }

            if (gameObject.tag == "Ken")
            {
                nameOfHit = "Hit_Ken";
                damage = 4f;
            }

        }

       
    }
    private void OnTriggerEnter(Collider c)
    {
        IDamageable damageableObject = c.GetComponent<IDamageable>();

        if (damageableObject != null && c.gameObject.tag != "PlayerHP")
        {
            damageableObject.TakeDamage(damage);
            TrashMan.spawn(nameOfHit, gameObject.transform.position, c.gameObject.transform.rotation);
        }
    }
}
