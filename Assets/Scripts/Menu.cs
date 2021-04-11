using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play(){
    	SceneManager.LoadScene("Map");
    }

    public void MenuPrincipal(){
        
    	SceneManager.LoadScene("Menu");
    }

    public void PlayAgain(){
    	SceneManager.LoadScene(PlayerPrefs.GetInt("levelAt"));
    }

    public void Map(){
    	SceneManager.LoadScene("Map");
    }

    public void NextLevel(){
        SceneManager.LoadScene(PlayerPrefs.GetInt("nextLevel"));
    }

    public void Quitter(){
        Application.Quit();
    }
}
