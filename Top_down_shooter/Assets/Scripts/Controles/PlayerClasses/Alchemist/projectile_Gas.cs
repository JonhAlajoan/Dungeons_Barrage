using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile_Gas : MonoBehaviour {

    public LayerMask collisionMask;
    float speed = 30;
    float damage = 1f;
    public Transform Hit_vfx;
    public bool firstHit = true;
    float lifetime = 3;
    float skinWidth = .1f;
    float count;
    Transform playerPos;
    bool canSpawnMore;

    private void OnEnable()
    {
        canSpawnMore = true;
    }

    void Start()
    {


        Collider[] initialCollisions = Physics.OverlapSphere(transform.position, .1f, collisionMask);
        if (initialCollisions.Length > 0)
        {
            OnHitObject(initialCollisions[0]);
        }

        playerPos = GameObject.FindGameObjectWithTag("PlayerHP").GetComponent<Transform>();
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    void Update()
    {
        count += 1 * Time.deltaTime;
        if (count >= 2)
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
        Transform enemyPos = hit.collider.GetComponent<Transform>();


        if (damageableObject != null)
        {            
            TrashMan.spawn("hit_FirstAlchemist", gameObject.transform.position, gameObject.transform.rotation);
            TrashMan.spawn("Alchemy_Gas", gameObject.transform.position, gameObject.transform.rotation);
            damageableObject.TakeDamage(damage);
        }

        canSpawnMore = false;
        TrashMan.despawn(gameObject);

    }

    void OnHitObject(Collider c)
    {
        IDamageable damageableObject = c.GetComponent<IDamageable>();
        if (damageableObject != null)
        {
            damageableObject.TakeDamage(damage);


            Debug.Log("Spawnou e mudou a rotação");
        }
        TrashMan.despawn(gameObject);
    }
}
