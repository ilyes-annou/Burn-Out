using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D (Collider2D touche){
    	Joueur joueur = touche.GetComponent<Joueur>();
    	if(joueur != null){
    		joueur.GetComponent<Joueur>().Meurt();
       	}
   
    }
}
