using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamePriestVortex : MonoBehaviour {

        
      
        public float damage = 15f;
 
        float delay = 4.8f;

        Collider startCollider;
        audioController sfxController;

        private void OnEnable()
        {
        startCollider = GetComponent<Collider>();
        startCollider.enabled = false;
        sfxController = GameObject.FindGameObjectWithTag("audioSource").GetComponent<audioController>();
        StartCoroutine("startCausingDamage");
        }




    IEnumerator startCausingDamage()
        {
             yield return new WaitForSeconds(1.3f);
            sfxController.PlaySFXSounds("Lightning");
             startCollider.enabled = true;
        yield return new WaitForSeconds(0.2f);
        startCollider.enabled = false;
        }

        void OnTriggerEnter(Collider hit)
        {
            IDamageable damageableObject = hit.GetComponent<IDamageable>();
            if (damageableObject != null && hit.gameObject.tag != "PlayerHP")
            {
                damageableObject.TakeDamage(damage);
                TrashMan.spawn("hit_Priest", hit.transform.position, hit.transform.rotation);
            }
        }


    
}
