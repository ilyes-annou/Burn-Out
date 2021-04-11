using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionNiveau : MonoBehaviour{

	public bool deverouille;
	public Image imageDeverouille;

	private void Update(){
		UpdateLevelImage();
	}

	private void UpdateLevelImage(){
		if(!deverouille){
			imageDeverouille.gameObject.SetActive(true);

		}
		else{
			imageDeverouille.gameObject.SetActive(false);
		}
	}
   
}
