using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.PostProcessing;
public class controllerBerserk : LivingEntity {

    /*Code made to control the main character. It does the movement, instantiation of bullets, vortex spawning and hud treatment for HP
	 * Variables: 
	 * 		- hAxis and vAxis to get the horizontal and vertical axis
	 * 		- controller is Main character controller reference;
	 * 		- viewCamera is Main camera reference;
	 * 		- crosshairs is the reference to the crosshair used in the "cameraUI" part
	 * 		- textBombCooldown is the reference to UI, to show the bomb cooldown left
	 * 		- muzzle and muzzle 2 references to both muzzles that are used to spawn the main char's bullets
	 * 		- Bomb references the vortex prefab, bombMuzzle references the muzzle position and rotation to spawn the vortex
	 * 		- projectile is the reference for the bullets prefab
	 * 		- Msbetweenshots controls the milisenconds between each player's shot. Muzzle velocity defines the player's projectile speed
	 * 		- HealthAux gets the reference of the health from the livingEntity script and passes it to healthTxt to show it at the Canvas
	 * 		- Timereference to get the reference of time (1s = whatever fps);
	 * 		- speed is Player's speed
	 */

    bool allowTogglePower = true;
    //
    float hAxis;
    float vAxis;
    //
    public CharacterController controller;
    public Animator animaController;
    //
    public Camera viewCamera;
    //
    public Transform crosshairs;
    //
    public Text textBombCooldown;
    public Text textWPower;
    //
    public Transform muzzle;

    public audioController sfxController;
    //
    public Transform bomb;
    public Transform bombMuzzle;
    public int bombCooldown = 0;
    //
    public Projectile projectile;
    public int WPower;
    //
    public float msBetweenShots = 100;
    public float muzzleVelocity = 35;
    float nextShotTime;
    //
    float healthAux;
    public Text healthTxt;
    //
    float timeReference;
    //
    public float speed = 1;
    //
    public float gravity = 10.0f;
    private Vector3 moveDirection = Vector3.zero;
    public GameObject canvasPause;
    public GameObject canvasComum;
    public PostProcessingProfile cameraB;
    int flag = 0;
    public int flagCursor = 1;

    void Awake()
    {
        //Set the cursor to be invisible at runtime
        Cursor.visible = false;
    }


    protected override void Start()
    {
        //Base.Start uses the LivingEntity protected function to start a player's HP
        base.Start();

        /*	Variables: 	
		 *	- HealthAux gets the health from livingentity to use it on canvas
		 *	- animeController gets the animator component
		 *	- time reference makes 1s = whatever fps
		 *	- bombCooldown set to 1 because it bugs when put 0
		 */
        healthAux = GetComponent<LivingEntity>().auxHealth;
        controller = GetComponent<CharacterController>();
        //	animaController = GetComponent<Animator> ();
        viewCamera = Camera.main;
        timeReference = 1 * Time.deltaTime;
        bombCooldown = 1;
        WPower = 1;
        cameraB.depthOfField.enabled = false;

    }


    //This function makes the  player look centralized
    public void LookAt(Vector3 lookPoint)
    {
        Vector3 heightCorrectedPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
        transform.LookAt(heightCorrectedPoint);
    }

    //gets the gunheight(used in the case of switching between weapons)
    public float GunHeight
    {
        get
        {
            return muzzle.position.y;
        }
    }

    /* This function makes the player shoots projectiles at the muzzle and muzzle2 position and rotation.
	 * 	Further explanation: 
	 * 		- NextShotTime is the time passed in game + milisecondsbetweenshots divided by 1000
	 * 		- The instantiate was used instead of the Trashman pooling because it does break the game, as the player stops being recognized
	 * 		- i don't even know why in the flying fuck i've put the control for the projectile speed here
	 * 		- the lookat makes the projectile be projected at the crosshair for better interaction
	 * 		- the newprojectile.transform.rotate makes the "recoil" from the weapon
	 */
    public void Shoot()
    {
        if (Time.time > nextShotTime)
        {
            nextShotTime = Time.time + msBetweenShots / 1000;
            animaController.SetTrigger("attack");
        }

    }


    //The bomb function instantiates a new vortex at the direction that the player is facing and triggers the animation



    public void pauseGame()
    {
        flagCursor = 0;
        cameraB.depthOfField.enabled = true;
        canvasPause.SetActive(true);
        canvasComum.SetActive(false);
        if (Cursor.visible = false)
            Cursor.visible = true;
        Time.timeScale = 0;
    }

    public void unpauseGame(int numCursorFlag)
    {
        if (numCursorFlag == 1)
        {
            flagCursor = 1;
        }
        else
        {
            flagCursor = 0;
        }
    }

    /*	Further explanation of the update function: 
	 *		- Vector3 movement Takes the horizontal and vertical axis, multiplies it by the speed and time.Deltatime, then is passed as parameter to be used for the controller
	 *		- bombCooldown loop is to reduce the time 1 second (for every second passed), to get the cooldown to 0 before the vortex can be used
	 *		- textBombCoold.text makes the actual bombCooldown to be passed as string to the canvas (the "#0" makes the value shown to be only the first number)
	 *		- Ray ray makes a ray to the mouseposition
	 *		- the Plane GourndPlane makes the raycast based in the gunHeight
	 *		- The if makes the crosshair look at the raycast position, since the point is the raydistance in ray
	 */
    void Update()
    {

        gameObject.SetActive(true);
        hAxis = Input.GetAxis("Horizontal");
        vAxis = Input.GetAxis("Vertical");

        //se apertar pra direita e pra cima
        Vector3 movement = new Vector3(hAxis, -10.0f, vAxis) * speed * Time.deltaTime;
        if(vAxis > 1 && hAxis > 1)
        {
            animaController.SetTrigger("runFront");
        }

        if (vAxis < 1 && hAxis < 1)
        {
            animaController.SetTrigger("runBack");
        }

        if (flagCursor == 1)
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }

        controller.Move(movement);

        textBombCooldown.text = bombCooldown.ToString("#0");
        textWPower.text = WPower.ToString("#0");

        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.up * GunHeight);
        float rayDistance;

        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            this.LookAt(point);

            crosshairs.position = point;
        }

        if (Input.GetMouseButton(0))
        {

            Shoot();
            sfxController.PlaySFXSounds("bullet_arcane");
        }
        else
        {
            animaController.SetTrigger("backToIdle");

        }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pauseGame();
            }
            healthAux = GetComponent<LivingEntity>().auxHealth;
            healthTxt.text = healthAux.ToString();

    }
}

