using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinNiveau : MonoBehaviour
{
	public int sceneSuivante;

    void Start()
    {
        PlayerPrefs.SetInt("levelAt", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("nextLevel", sceneSuivante);
        //sceneSuivante= SceneManager.GetActiveScene().buildIndex+1;
    }

    public void OnTriggerEnter2D(Collider2D collider){
    	if(collider.gameObject.tag=="Player"){

    		SceneManager.LoadScene("Win");


    		/*if(sceneSuivante>PlayerPrefs.GetInt("levelAt")){
    			PlayerPrefs.SetInt("levelAt",sceneSuivante);
    		}*/
    	}
    }

}
