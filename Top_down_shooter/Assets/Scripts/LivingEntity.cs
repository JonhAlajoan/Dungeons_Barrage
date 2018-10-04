using UnityEngine;
using System.Collections;
using BayatGames.SaveGameFree;
using UnityEngine.PostProcessing;
public class LivingEntity : MonoBehaviour, IDamageable {
    GameObject managerObject;
	public float startingHealth;
	protected float health;
	protected bool dead;
	public Animator animController;
	public event System.Action OnDeath;
	public float auxHealth;
	public GameObject dropBomb;
	public GameObject dropWPower;
	GameObject spawnControl;
	GameObject scoreUpdt;
	int numRandom;
	Quaternion flipSpawn;
	public Material modifiableColor;
    int TypeOfClass;
    Camera mainCamera;
    PostProcessingProfile postProcessing;
  SmoothFollow camerashaker;
    Animator cameraAnimController;
    protected virtual void Start() {

        dead = false;
		health = startingHealth;
		auxHealth = health;
        
        spawnControl = GameObject.FindWithTag ("Spawner");	
		scoreUpdt = GameObject.FindWithTag ("Score");
        managerObject = GameObject.FindWithTag("Manager");
        TypeOfClass = managerObject.GetComponent<ManagerClasses>().ClassBeingUsed;
        

        mainCamera = Camera.main;
        cameraAnimController = mainCamera.GetComponent<Animator>();
        camerashaker = mainCamera.GetComponent<SmoothFollow>();
        postProcessing = mainCamera.GetComponent<PostProcessingBehaviour>().profile;

        flipSpawn = Quaternion.Euler (0, 0, 0);
		//modifiableColor.color = Color.white;
	}


	public void randomDropWPower(){

        switch(TypeOfClass)
        {
            case 0:
                numRandom = Random.Range(0, 2);
                if (numRandom == 1)
                {
                    GameObject newWpowerPickup = Instantiate(dropWPower, new Vector3(gameObject.transform.position.x, 2.45f, gameObject.transform.position.z), gameObject.transform.rotation);
                }
                break;

            case 1:
                int numRandomico = Random.Range(0, 30);

                ShamanController shammyContr = GameObject.FindGameObjectWithTag("PlayerHP").GetComponent<ShamanController>();
                
 
                if (numRandomico == 1)
                {
                    if(shammyContr.StateKen == false)
                    {
                        GameObject newBombPickup = TrashMan.spawn("runeKen", new Vector3(gameObject.transform.position.x, 2.45f, gameObject.transform.position.z), gameObject.transform.rotation);
                        
                        shammyContr.SetStateOfRunes(true, "StateKen");
                    }                    
                }
                if (numRandomico == 2)
                {
                    if(shammyContr.StateIsa == false)
                    {
                        GameObject newBombPickup = TrashMan.spawn("runeIsa", new Vector3(gameObject.transform.position.x, 2.45f, gameObject.transform.position.z), gameObject.transform.rotation);
                        shammyContr.SetStateOfRunes(true, "StateIsa");
                    }                    
                }
                if (numRandomico == 3)
                {
                    if(shammyContr.StateJera == false)
                    {
                        GameObject newBombPickup = TrashMan.spawn("runeJera", new Vector3(gameObject.transform.position.x, 2.45f, gameObject.transform.position.z), gameObject.transform.rotation);
                        shammyContr.SetStateOfRunes(true, "StateJera");
                    }
                }
                break;

            case 2:
                int numRandomicos = Random.Range(0, 8);
                if (numRandomicos == 1)
                {
                    GameObject newWpowerPickup = Instantiate(dropWPower, new Vector3(gameObject.transform.position.x, 2.45f, gameObject.transform.position.z), gameObject.transform.rotation);
                }
                break;

            case 3:
                int numRandomicoss = Random.Range(0, 8);
                if (numRandomicoss == 1)
                {
                    GameObject newWpowerPickup = Instantiate(dropWPower, new Vector3(gameObject.transform.position.x, 2.45f, gameObject.transform.position.z), gameObject.transform.rotation);
                }
                break;

            case 4:
                int numRandomicoz = Random.Range(0, 8);
                if (numRandomicoz == 0)
                {
                    
                }
                break;
            case 5:
                int numRandomsz = Random.Range(0, 6);

                if (numRandomsz == 1)
                {
                    int numRandomicozs = Random.Range(1, 5);
                    if (numRandomicozs == 1)
                    {
                        GameObject newBombPickup = TrashMan.spawn("Alchemy_Circle_Gas", new Vector3(gameObject.transform.position.x, 2.45f, gameObject.transform.position.z), gameObject.transform.rotation);
                    }
                    if (numRandomicozs == 2)
                    {
                        GameObject newBombPickup = TrashMan.spawn("Alchemy_Circle_Life", new Vector3(gameObject.transform.position.x, 2.45f, gameObject.transform.position.z), gameObject.transform.rotation);
                    }
                    if (numRandomicozs == 3)
                    {
                        GameObject newBombPickup = TrashMan.spawn("Alchemy_Circle_Machinegun", new Vector3(gameObject.transform.position.x, 2.45f, gameObject.transform.position.z), gameObject.transform.rotation);
                    }
                    if (numRandomicozs == 4)
                    {
                        GameObject newBombPickup = TrashMan.spawn("Alchemy_Circle_Thunder", new Vector3(gameObject.transform.position.x, 2.45f, gameObject.transform.position.z), gameObject.transform.rotation);
                    }
                }
                break;
        }

    }

	public void randomDropBomb()
    {
        switch(TypeOfClass)
        {
            case 0:
                numRandom = Random.Range(0, 9);
                if (numRandom == 8)
                {
                    GameObject newBombPickup = Instantiate(dropBomb, new Vector3(gameObject.transform.position.x, 2.45f, gameObject.transform.position.z), gameObject.transform.rotation);
                }
                break;

            case 1:
                int numRandoms = Random.Range(0, 15);
                if (numRandoms == 8)
                {
                    GameObject newBombPickup = Instantiate(dropBomb, new Vector3(gameObject.transform.position.x, 2.45f, gameObject.transform.position.z), gameObject.transform.rotation);
                }
                break;

            case 2:
                int numRandomss = Random.Range(0, 10);
                if (numRandomss == 4)
                {
                    GameObject newBombPickup = Instantiate(dropBomb, new Vector3(gameObject.transform.position.x, 2.45f, gameObject.transform.position.z), gameObject.transform.rotation);
                }
                break;

            case 3:
                int numRandomsss = Random.Range(0, 15);
                if (numRandomsss == 8)
                {
                    GameObject newBombPickup = Instantiate(dropBomb, new Vector3(gameObject.transform.position.x, 2.45f, gameObject.transform.position.z), gameObject.transform.rotation);
                }
                break;
            case 4:
                int numRandomsz = Random.Range(0, 13);
                if (numRandomsz == 4)
                {
                    GameObject newBombPickup = Instantiate(dropBomb, new Vector3(gameObject.transform.position.x, 2.45f, gameObject.transform.position.z), gameObject.transform.rotation);
                }
                break;
            case 5:
                int numRandomszs = Random.Range(0, 12);
                if (numRandomszs == 8)
                {
                    GameObject newBombPickup = Instantiate(dropBomb, new Vector3(gameObject.transform.position.x, 2.45f, gameObject.transform.position.z), gameObject.transform.rotation);
                }
                break;
            case 6:
                int numRandomszss = Random.Range(0, 15);
                if (numRandomszss == 5)
                {
                    GameObject newBombPickup = Instantiate(dropBomb, new Vector3(gameObject.transform.position.x, 2.45f, gameObject.transform.position.z), gameObject.transform.rotation);
                }
                break;
            case 7:
                int numRandomszsss = Random.Range(0, 15);
                if (numRandomszsss == 5)
                {
                    GameObject newBombPickup = Instantiate(dropBomb, new Vector3(gameObject.transform.position.x, 2.45f, gameObject.transform.position.z), gameObject.transform.rotation);
                }
                break;


        }

    }
	public void TakeHit(float damage, RaycastHit hit) {
	
		if (gameObject.tag == "PlayerHP") {
            StartCoroutine(shake());
			camerashaker.Shake(0.1f,0.2f,5f);
			TakeDamage (damage);
            StartCoroutine("ChangeColor");
          
        } else {
			TakeDamage (damage);
		}
	}

    public void Heal(float quantityHealed)
    {
        if(quantityHealed + health < startingHealth)
        {
            health += quantityHealed;
        }       

        if(quantityHealed + health >= startingHealth)
        {
            health = startingHealth;
        }
        auxHealth = health;
    }

    public void HealAlchemist(float quantityHealed)
    {
        if (quantityHealed + health <= 20)
        {
            health += quantityHealed;
        }
        auxHealth = health;
        
    }

    public void TakeDamage(float damage) {

		health -= damage;
		auxHealth = health;

		if (health <= 0 && !dead) {
			if (gameObject.tag == "PlayerHP") {
                modifiableColor.color = Color.white;
				Die ();
			} else {
				spawnControl = GameObject.FindWithTag ("Spawner");	
				spawnControl.GetComponent<Spawner>().OnEnemyDeath();
				scoreUpdt.GetComponent<Score> ().updateScoreEnemyDeath ();
				gameObject.GetComponent<LivingEntity> ().randomDropBomb ();
				gameObject.GetComponent<LivingEntity> ().randomDropWPower();
				Die();
			}
		}
	}

	IEnumerator ChangeColor(){
		modifiableColor.color = Color.red;
		yield return new WaitForSeconds (0.2f);
		modifiableColor.color = Color.white;


	}

    IEnumerator shake()
    {
        cameraAnimController.SetBool("CamShake", true);
        yield return new WaitForSeconds(0.1f);
        cameraAnimController.SetBool("CamShake", false);
    }

	[ContextMenu("Self Destruct")]
	protected void Die() {
		dead = true;
		if (OnDeath != null) {
			OnDeath();
		}
		TrashMan.spawn ("Enemy_Explosion", gameObject.transform.position, flipSpawn);
		TrashMan.despawn (gameObject);
		dead = false;
		auxHealth = startingHealth;
		health = startingHealth;
	}
}