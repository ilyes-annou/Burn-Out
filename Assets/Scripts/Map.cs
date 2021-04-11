using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour
{
	public Button[] niveaux;

	void Start(){
		Debug.Log("Current lvl" +PlayerPrefs.GetInt("levelAt"));
		Debug.Log("Next lvl" +PlayerPrefs.GetInt("nextLevel"));

		for(int i=0;i<niveaux.Length;i++){
			if(i<=PlayerPrefs.GetInt("levelAt")-2){
				niveaux[i].interactable=true;
				niveaux[i].transform.GetChild(1).gameObject.GetComponent<Image>().color=new Color(0f, 0f, 0f, 0f)/*.SetActive(false)*/;
			}

		}
		/*if(PlayerPrefs.GetInt("nextLevel")==3){
			niveaux[]
		}*/
	}
    public void Plaines(){
    	SceneManager.LoadScene("Plaines");
    }
    public void Montagnes(){
    	SceneManager.LoadScene("Montagnes");
    }
    public void Foret(){
    	SceneManager.LoadScene("Foret");
    }
}
