using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnnemiFx : MonoBehaviour
{
    public AIPath chemin;

    // Update is called once per frame
    void Update()
    {

    	if(chemin.desiredVelocity.x>= 0.01f){
    		transform.localScale= new Vector3(-4f,4f,1f);
    	}

    	else if (chemin.desiredVelocity.x<= -0.01f){
    		transform.localScale= new Vector3(4f,4f,1f);
    	}
        
    }
}
