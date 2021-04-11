using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
	public static bool enPause=false;
	public GameObject menuPause;
    // Update is called once per frame
    void Update()
    {

    	if(Input.GetKeyDown(KeyCode.Return)){
    		if(enPause){
    			Reprendre();
    		}
    		else {
    			Pauser();
    		}
    	}
        
    }

    public void Reprendre(){
    	menuPause.SetActive(false);
    	Time.timeScale=1f;
    	enPause=false;


    }

    public void Pauser(){
    	menuPause.SetActive(true);
    	Time.timeScale=0f;
    	enPause=true;
    }

    public void Carte(){
    	Time.timeScale=1f;
    	SceneManager.LoadScene("Map");

    }
}

