using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class familiar : MonoBehaviour
{
    ParticleSystem.MainModule settings;
    float count;

    private void OnEnable()
    {
        count = 17.3f;
    }
    private void Start()
    {        
        settings = gameObject.GetComponent<ParticleSystem>().main;
        settings.startSpeed = 17.3f;
    }

    private void Update()
    {
        count  -= 7 * Time.deltaTime;
        settings.startSpeed = count;
    }

    IEnumerator destroyObj(IDamageable objectToBeDestroyed)
    {
        
        yield return new WaitForSeconds(3f);
        count = 0;
        objectToBeDestroyed.TakeDamage(40);
    }
    

    void OnTriggerEnter(Collider c)
    {
        IDamageable damageableObject = c.GetComponent<IDamageable>();

        if (damageableObject != null && c.gameObject.tag != "PlayerHP")
        {
            StartCoroutine(destroyObj(damageableObject));
        }
       
    }
}