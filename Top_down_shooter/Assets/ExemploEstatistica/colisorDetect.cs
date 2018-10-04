using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisorDetect : MonoBehaviour {

	public Transform Cubo;
	//public Transform cuboTransform;
	public int contLaranja;
	public int contVermelho;
	public int contRoxo;
	public int contVerde;
	public int contGeral;
	public ControleGame idCubo;
	bool flagPrimeiroTiro;
	public int colisao;
	float incremento;
	int auxCont;
	public ControleGame camerass;
	public bool flagMultLaranja;
	public bool flagMultVermelho;
	public int colImport;

	public Transform spawn;


	void Start () {
		
		contLaranja = 1;
		contVermelho = 1;
		flagMultLaranja = false;
		flagMultVermelho = false;




	}


	
	// Update is called once per frame
	void Update () {

		colImport = camerass.col;
		flagMultLaranja = false;
		flagMultVermelho = false;
		
		if (Cubo.tag == "Laranja") {
			camerass.flagCuboLaranja = contLaranja;


		}


		if (Cubo.tag == "Vermelho") 
		{
			camerass.flagCuboVermelho = contVermelho;

		}
			
		
		
	}




}
