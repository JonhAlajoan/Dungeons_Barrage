using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;
using UnityEngine.PostProcessing;
using UnityEngine.UI;

public abstract class ClassesPlayer : MonoBehaviour, IDamageable {

    public event System.Action OnDeath;

    protected Camera mainCamera;

    Animator cameraAnimController;

    public Material modifiableColor;

    protected PostProcessingProfile postProcessing;

    SmoothFollow camerashaker;

    protected bool dead;
    public bool isControllerConnected;

    protected Transform crosshairs;

    public audioController sfxController;

    private Vector3 moveDirection = Vector3.zero;

    protected Rigidbody thisRigidBody;

   protected bool hasFoundAllReferences;
        

    #region SERIALIZED_FLOAT_VARIABLES
    [SerializeField]
    protected Animator animaController;
    //
    [Header("Character atributes")]
        [SerializeField]
        [Tooltip("Starting health of the class")]
            protected float startingHealth;

        [SerializeField]
        [Tooltip("Current Health of the class")]
            protected float health;

        [SerializeField]
        [Tooltip("Time between each shot or melee attack")]
            public float msBetweenShots;

        [SerializeField]
        [Tooltip("Speed of the class")]
            public float speed;
    [Space(5)]
    #endregion

    #region PROTECTED_VARIABLES_SERIALIZED
    [Header("Texts from the HUD that can be freely modified")]
        [SerializeField]
            public Text wPowerSub;
        [SerializeField]
            protected Text textBombCooldown;
        [SerializeField]
            protected Text textWPower;
        [SerializeField]
            public Text healthTxt;

    [Header("Character Controller")]
        [SerializeField]
            [Tooltip("Controller of the specific class")]
                protected CharacterController controller;
    [Space(5)]

    [Header("Character Controller")]
        [SerializeField]
            [Tooltip("Muzzle of the character (If ranged)")]
                protected Transform muzzle;

        [SerializeField]
            [Tooltip("Muzzle of the character's special (if needed)")]
                protected Transform specialMuzzle;
    [Space(5)]

    [Header("Canvas of the puase menu and the common HUD")]
        [SerializeField]
            [Tooltip("Canvas from the pause menu")]
                protected GameObject canvasPause;
        [SerializeField]
            [Tooltip("Canvas from the normal HUD")]
                protected GameObject canvasComum;
    [Space(5)]
    #endregion

    #region FLOAT_VARIABLES
    protected float hAxis;
    protected float vAxis;

    protected float nextShotTime;    
    protected float gravity = 10.0f;
    #endregion

    #region GAMEOBJECT_VARIABLES
    protected GameObject objectAnimator;
    protected GameObject objectSfxController;
    protected GameObject spawnControl;
    protected GameObject scoreUpdt;
    protected GameObject objectManager;
    protected GameObject objectTextBomb;
    protected GameObject objectTextHealth;
    protected GameObject objectTextWPower;
    protected GameObject objectCanvas;
    protected GameObject objectCanvasPause;
    protected GameObject objectCamera;
    protected GameObject objectCross;
    #endregion

    #region INT_VARIABLES
    public int specialQuantity;
    public int WPower;
    int flag = 0;
    public int flagCursor = 1;
    int TypeOfClass;

    #endregion

 
    protected virtual void Start()
    {
        hasFoundAllReferences = false;
        dead = false;
        health = startingHealth;
        mainCamera = Camera.main;
        specialQuantity = 0;
        WPower = 0;
        isControllerConnected = false;
    }

    public virtual void Update()
    {
        if(hasFoundAllReferences == false)
        {
            if(healthTxt == null || textWPower == null || wPowerSub == null || canvasPause == null || canvasComum == null)
            {
                #region OBJECTS_TO_BE_FOUND
                spawnControl = GameObject.FindWithTag("Spawner");
                scoreUpdt = GameObject.FindWithTag("Score");
                objectManager = GameObject.FindWithTag("Manager");
                objectSfxController = GameObject.FindWithTag("audioSource");
                objectTextBomb = GameObject.FindWithTag("textBomb");
                objectTextHealth = GameObject.FindWithTag("textHealth");
                objectTextWPower = GameObject.FindWithTag("textWpower");
                objectCanvas = GameObject.FindWithTag("canvasComum");
                objectCanvasPause = GameObject.FindWithTag("canvasPause");
                objectCross = GameObject.FindWithTag("Cross");
                #endregion

                #region GETCOMPONENTS_OF_VARIABLES

                TypeOfClass = objectManager.GetComponent<ManagerClasses>().ClassBeingUsed;
                crosshairs = objectCross.GetComponent<Transform>();
                cameraAnimController = mainCamera.GetComponent<Animator>();
                camerashaker = mainCamera.GetComponent<SmoothFollow>();
                postProcessing = mainCamera.GetComponent<PostProcessingBehaviour>().profile;
                controller = GetComponent<CharacterController>();
                wPowerSub = GameObject.FindWithTag("textWpowerSub").GetComponent<Text>();
                textBombCooldown = objectTextBomb.GetComponent<Text>();
                healthTxt = objectTextHealth.GetComponent<Text>();
                textWPower = objectTextWPower.GetComponent<Text>();
                thisRigidBody = gameObject.GetComponent<Rigidbody>();
                sfxController = objectSfxController.GetComponent<audioController>();
                canvasPause = objectCanvasPause;
                canvasComum = objectCanvas;

                #endregion
                postProcessing.depthOfField.enabled = false;
                canvasPause.SetActive(false);
                postProcessing.depthOfField.enabled = false;
                hasFoundAllReferences = true;


            }

        }
        
        hAxis = Input.GetAxis("Horizontal");
        vAxis = Input.GetAxis("Vertical");
        

        Vector3 movement = new Vector3(hAxis, -10.0f, vAxis) * speed * Time.deltaTime;
       

        controller.Move(movement);
        healthTxt.text = health.ToString();
        textBombCooldown.text = specialQuantity.ToString("#0");

		Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

		Plane groundPlane = new Plane(Vector3.up, Vector3.up * GunHeight);
		float rayDistance;

		if (groundPlane.Raycast(ray, out rayDistance))
		{
			Vector3 point = ray.GetPoint(rayDistance);
			this.LookAt(point);
			crosshairs.position = point;
		}

		if (flagCursor == 1)
        {
            canvasPause.SetActive(false);
            postProcessing.depthOfField.enabled = false;
            Cursor.visible = false;
        }

        else
        {
            Cursor.visible = true;
        }
        
        

        #region MOUSE_AND_KEYBOARD_INPUTS
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }

        if(Input.GetButtonDown("Fire2"))
        {
            if (TypeOfClass == 1 || TypeOfClass == 6 || TypeOfClass == 7)
            {
                AttackRight();
            }
        }        

        if (Input.GetButtonDown("Fire3"))
        {
            Special();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame();
        }

        if(Input.GetKeyDown(KeyCode.V))
        {
            specialQuantity += 10;
        }
        #endregion
    }

    public abstract void Attack();

    public abstract void AttackRight();

    public abstract void Special();

  
    public void pauseGame()
    {
        flagCursor = 0;
        postProcessing.depthOfField.enabled = true;

        canvasPause.SetActive(true);
        canvasComum.SetActive(false);

        if (Cursor.visible == false)
            Cursor.visible = true;
        Time.timeScale = 0;
    }

    public void unpauseGame(int numCursorFlag)
    {
        if (numCursorFlag == 1)
        {
            flagCursor = 1;
            postProcessing.depthOfField.enabled = false;
            Cursor.visible = false;
        }
        else
        {
            flagCursor = 0;
        }
    }

    public void LookAt(Vector3 lookPoint)
    {
        Vector3 heightCorrectedPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
        transform.LookAt(heightCorrectedPoint);
    }

    public float GunHeight
    {
        get
        {
            return muzzle.position.y;
        }
    }

    public void increaseBomb()
    {
        if (specialQuantity < 5)
        {
            specialQuantity++;
        }
    }

    public void increaseWPower()
    {
        WPower++;
    }

    public void TakeHit(float damage, RaycastHit hit)
    {
        if (gameObject.tag == "PlayerHP")
        {
            StartCoroutine(shake());
            camerashaker.Shake(0.1f, 0.2f, 5f);
            TakeDamage(damage);
            StartCoroutine("ChangeColor");
        }
        else
        {
            TakeDamage(damage);
        }
    }

    public void Heal(float quantityHealed)
    {
        if (quantityHealed + health < startingHealth)
        {
            health += quantityHealed;
        }

        if (quantityHealed + health >= startingHealth)
        {
            health = startingHealth;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0 && !dead)
        {
                modifiableColor.color = Color.white;
                Die();    
        }
    }



    IEnumerator ChangeColor()
    {
        modifiableColor.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        modifiableColor.color = Color.white;
    }

    IEnumerator shake()
    {
        cameraAnimController.SetBool("CamShake", true);
        yield return new WaitForSeconds(0.1f);
        cameraAnimController.SetBool("CamShake", false);
    }

    [ContextMenu("Self Destruct")]
    protected void Die()
    {
        dead = true;

        if (OnDeath != null)
        {
            OnDeath();
        }

        TrashMan.spawn("Enemy_Explosion", gameObject.transform.position, new Quaternion(0,0,0,0));

        TrashMan.despawn(gameObject);
        dead = false;
        health = startingHealth;
    }
}
