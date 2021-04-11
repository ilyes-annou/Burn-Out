using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opossum : MonoBehaviour
{
    public float vitesse;
    public Rigidbody2D rb;
    bool gauche;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    	transform.Translate(Vector2.left * vitesse * Time.deltaTime);
        
    }

    void OnCollisionEnter2D(Collision2D collision){
    	if(collision != null /*&& !collision.collider.CompareTag("Player")*/){

    		gauche=!gauche;

    	}

    	if(gauche){
    		gameObject.transform.rotation = Quaternion.Euler(0,0,0);
    	}

    	else{
    		gameObject.transform.rotation = Quaternion.Euler(0,180,0);
    	}
    }
}
