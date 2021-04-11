using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vie : MonoBehaviour
{
	public Slider slider;
	public Gradient couleur;
	public Image valeur;
    // Start is called before the first frame update
    public void SetVie(int vie){
    	slider.value=vie;
    	valeur.color=couleur.Evaluate(slider.normalizedValue);
    }

    public void SetVieMax(int vie){
    	slider.maxValue=vie;
    	slider.value=vie;

    	couleur.Evaluate(1f);

    }
}
