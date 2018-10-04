using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageDealerFlame : MonoBehaviour {
    public LayerMask collisionMask;
    public float damage = 5f;
    public float radius;
    float delay = 4.8f;
    bool coRoutineStart = false;
    float count;
    Collider startCollider;
    audioController sfxController;

    private void OnEnable()
    {
        startCollider = GetComponent<Collider>();
        startCollider.enabled = false;
        count = 1 * Time.deltaTime;
        sfxController = GameObject.FindGameObjectWithTag("audioSource").GetComponent<audioController>();
    }

    void Start()
    {
        radius = 10f;
        sfxController.PlaySFXSounds("cannonball_explosion");
    }

    public void Update()
    {
        count += 1 * Time.deltaTime;
        if (count >= 4.5f)
        {
            startCollider.enabled = true;
            count = 0;
        }

    }

    void OnTriggerEnter(Collider hit)
    {
        IDamageable damageableObject = hit.GetComponent<IDamageable>();
        if (damageableObject != null && hit.gameObject.tag!="PlayerHP")
        {
            TrashMan.spawn("hit_Engineer", hit.transform.position, hit.transform.rotation);
            damageableObject.TakeDamage(damage);
        }
    }

    private void OnTriggerStay(Collider hit)
    {
        IDamageable damageableObject = hit.GetComponent<IDamageable>();
        if (damageableObject != null && hit.gameObject.tag != "PlayerHP")
        {
            TrashMan.spawn("hit_Engineer", hit.transform.position, hit.transform.rotation);
            damageableObject.TakeDamage(damage);
        }
    }
}
