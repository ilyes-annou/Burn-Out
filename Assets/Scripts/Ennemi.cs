using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : MonoBehaviour
{
	public int pvMax;
	public int pv;
	public Animator animateur;
	public LayerMask coucheJoueur;
	public int attaque = 1;
    public GameObject explosion;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
    	pv=pvMax;
        rb=GetComponent<Rigidbody2D>(); 
    	   
    }

    void Update(){
    	//coup();
    }

    public void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag=="Player"){

           collider.GetComponent<Joueur>().prendDegats(attaque);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag=="Player"){

           collision.gameObject.GetComponent<Joueur>().prendDegats(attaque);
        }
    }
    

    /*void coup(){
    	
    	//animateur.SetTrigger("coup");
    	Collider2D[] touches =Physics2D.OverlapCircleAll(GetComponent<Transform>().position, 0.6f, coucheJoueur);
   		foreach(Collider2D joueur in touches){
    		joueur.GetComponent<Joueur>().prendDegats(attaque);
    		
    	}
    	
    }*/

    //GameObject.Find("perso").GetComponent<Collider2D>();

    public void prendDegats(int degats){
    	pv-=degats;

    	if(pv<=0){
    		Meurt();
    	}
    }

    public void Meurt(){
        Instantiate(explosion, rb.position, GetComponent<Transform>().rotation);
    	Destroy(gameObject, 0.2f);
    }

    // Update is called once per frame
    
}
