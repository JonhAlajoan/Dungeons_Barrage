using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileEngineer : MonoBehaviour {

    public LayerMask collisionMask;
    float speed = 60;
    float damage = 3.0f;
    float lifetime = 1;
    float skinWidth = .1f;
    float count;
    void Start()
    {

        Collider[] initialCollisions = Physics.OverlapSphere(transform.position, .1f, collisionMask);
        if (initialCollisions.Length > 0)
        {
            OnHitObject(initialCollisions[0]);
        }

    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    void Update()
    {
        count += 1 * Time.deltaTime;
        if (count >= 1.5f)
        {
            TrashMan.despawn(gameObject);
            count = 0;
        }
        float moveDistance = speed * Time.deltaTime;
        CheckCollisions(moveDistance);
        transform.Translate(Vector3.forward * moveDistance);
    }


    void CheckCollisions(float moveDistance)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, moveDistance + skinWidth, collisionMask, QueryTriggerInteraction.Collide))
        {
            OnHitObject(hit);
        }
    }

    void OnHitObject(RaycastHit hit)
    {
        IDamageable damageableObject = hit.collider.GetComponent<IDamageable>();
        if (damageableObject != null)
        {
            damageableObject.TakeDamage(damage);
            TrashMan.spawn("hit_Engineer", gameObject.transform.position, gameObject.transform.rotation);
        }
        TrashMan.despawn(gameObject);

    }

    void OnHitObject(Collider c)
    {
        IDamageable damageableObject = c.GetComponent<IDamageable>();
        if (damageableObject != null)
        {
            damageableObject.TakeDamage(damage);
        }
        TrashMan.despawn(gameObject);
    }
}
