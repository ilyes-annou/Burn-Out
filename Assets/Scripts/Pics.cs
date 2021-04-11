using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pics : MonoBehaviour
{
	public LayerMask coucheJoueur;
   // Update is called once per frame
    void Update()
    {
        coup();
    }


    void coup(){
    	
    	//animateur.SetTrigger("coup");
    	Collider2D[] touches =Physics2D.OverlapCircleAll(GetComponent<Transform>().position, 0.3f, coucheJoueur);
   		foreach(Collider2D joueur in touches){
    		joueur.GetComponent<Joueur>().prendDegats(2);
    		
    	}
    	
    }
}
