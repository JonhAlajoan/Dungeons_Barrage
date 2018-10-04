using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleGame : MonoBehaviour {

	public int flagCuboLaranja;
	public int flagCuboVermelho;
	public Transform bombMuzzle;
	public Transform bomb;
	public Transform muzzleLaranja;
	public Transform muzzleVermelho;
	Transform posiSpawn;
	public int col;
	int round;
	int maior;
	public float delay;



	void Start () {
		delay = 100 * Time.deltaTime;

		maior = 0;
		//col = GetComponent<colisorDetect> ().colisao;
		flagCuboLaranja=0;
		flagCuboVermelho=0;
		col = 0;
	}

	void checaMaior(){
		
		if (flagCuboLaranja > flagCuboVermelho) {
			maior = flagCuboLaranja;
		} else {
			maior = flagCuboVermelho;
		}
	}		


	void FixedUpdate(){
		

	}

	void instanciarVortex()
	{
		if (col >= 8) 
		{
			checaMaior ();			
			//posiSpawn = target.GetComponent<colisorDetect> ().spawn;
			if (maior == flagCuboLaranja) {				
				Transform newBomb = Instantiate (bomb, muzzleLaranja.position, bombMuzzle.rotation) as Transform; 					
				newBomb.transform.Rotate (90, 0, 0);	
				col = 0;
			} else {
				Transform newBomb = Instantiate (bomb, muzzleVermelho.position, bombMuzzle.rotation) as Transform; 					
				newBomb.transform.Rotate (90, 0, 0);
				col = 0;
			}				
				
	


		}
	}

	IEnumerator addCol(){
		col++;

		yield return null;
	}
		

	void Update () {
		if (Input.GetMouseButtonDown (0)) {	

			StartCoroutine (addCol ());

		}

		instanciarVortex ();



						
	}
}
