using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class scriptPulo : MonoBehaviour
{
    Rigidbody rb;
    float velocidadePulo;

    int vida;

    int moedas;

    public Text moedasText;
    public Text vidaText;

    Animator animatorPlayer;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        velocidadePulo = 10f;
        vida = 3;
        moedas = 0;

        moedasText.text = "0";
        vidaText.text = "3";

        animatorPlayer = gameObject.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * velocidadePulo);
            animatorPlayer.SetTrigger("pulo");
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "head")
        {  
            Destroy(col.gameObject);
        }

        if(col.gameObject.tag == "body" && vida > 0)
        {
            vida--;
            vidaText.text = vida.ToString("#0");
        }

        if(col.gameObject.tag == "coin")
        {
            moedas++;
            moedasText.text = moedas.ToString("#0");
        }
    }

    private void Update()
    {
        
    }
}
