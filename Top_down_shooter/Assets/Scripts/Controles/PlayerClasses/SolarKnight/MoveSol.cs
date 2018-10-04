
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSol : MonoBehaviour
{
    public float damage = 100f;
    float count;
    Collider startCollider;
    float speed = 25;
    SolarKnightController solarKnightContr;
    Transform target;
    ParticleSystem particleSun;

    void OnEnable()
    {
        startCollider = GetComponent<Collider>();
        startCollider.enabled = false;
        target = null;
        particleSun = gameObject.GetComponent<ParticleSystem>();
    }

   

    IEnumerator delayBeforeExplosion()
    {
        solarKnightContr.isSunInteractive = false;
        solarKnightContr.isSpecialActive = false;
        target = null;
        solarKnightContr.crossPositionBombMoment = null;
        yield return new WaitForSeconds(3f);
        solarKnightContr.ZoomIn();        
        TrashMan.despawn(gameObject);        
    }

    private void Update()
    {
        solarKnightContr = GameObject.FindGameObjectWithTag("PlayerHP").GetComponent<SolarKnightController>();
        float moveDistance = speed * Time.deltaTime;    
        bool isSunReady = solarKnightContr.isSunInteractive;
       // target = solarKnightContr.crossPositionBombMoment;

        if(isSunReady == true)
        {
            target = solarKnightContr.crossPositionBombMoment;

            if(target)
            {
                startCollider.enabled = true;
                gameObject.transform.LookAt(target);
                gameObject.transform.Translate(Vector3.forward * moveDistance);
            }
            
        }
    }

    void OnTriggerEnter(Collider hit)
    {
        //Debug.Log("hitou algo");
        IDamageable damageableObject = hit.GetComponent<IDamageable>();
        if (damageableObject != null && hit.gameObject.tag != "PlayerHP")
        {
            Debug.Log("hit em um objecto com livingentity");
            damageableObject.TakeDamage(damage);
            StartCoroutine(delayBeforeExplosion());
            
           
            TrashMan.spawn("Sol_Explosion", hit.transform.position, hit.transform.rotation);            
        }
        
        if(hit.gameObject.tag == "Chao")
        {
            Quaternion newRot = new Quaternion(0, 0, 0, 0);
            StartCoroutine(delayBeforeExplosion());
            TrashMan.spawn("Sol_Explosion", gameObject.transform.position, newRot);
        }
    }
}