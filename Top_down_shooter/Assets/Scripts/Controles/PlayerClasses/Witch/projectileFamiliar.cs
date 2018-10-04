using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class projectileFamiliar : MonoBehaviour
{

    public LayerMask collisionMask;
    float speed = 20;
    float damage = 1.0f;
    public Transform Hit_vfx;
    public bool firstHit = true;
    float lifetime = 3;
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
        if (damageableObject != null)
        {
            damageableObject.TakeDamage(damage);
            TrashMan.spawn("FireDarkness", gameObject.transform.position, new Quaternion(90,0,0,0));
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
