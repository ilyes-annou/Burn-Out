using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tir : MonoBehaviour{

	public float vitesse= 20f;
	private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start(){ 
    	rb= GetComponent<Rigidbody2D>(); 
    	rb.velocity = transform.right * vitesse;
    	Destroy(gameObject, 0.5f);
        
    }

    void OnTriggerEnter2D (Collider2D touche){
    	Ennemi ennemi = touche.GetComponent<Ennemi>();
    	if(ennemi != null){
    		ennemi.GetComponent<Ennemi>().prendDegats(3);
    		Destroy(gameObject, 0);
    	}
   
    }

    
}
