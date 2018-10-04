using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileLife : MonoBehaviour {

    public LayerMask collisionMask;
    float speed = 30;
    float damage = 0.5f;
    public Transform Hit_vfx;
    public bool firstHit = true;
    float lifetime = 3;
    float skinWidth = .1f;
    float count;
    Transform playerPos;
    bool canSpawnMore;
  ClassesPlayer player;
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
        player = GameObject.FindGameObjectWithTag("PlayerHP").GetComponent<ClassesPlayer>();
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
            TrashMan.spawn("hit_Life", gameObject.transform.position, gameObject.transform.rotation);
            player.Heal(1f);
            GameObject heal = TrashMan.spawn("PlayerHeal", playerPos.transform.position, playerPos.transform.rotation);
            heal.transform.parent = player.transform;
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
        }
        TrashMan.despawn(gameObject);
    }
}
