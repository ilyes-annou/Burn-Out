using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;

	public bool estTourne = false;
	public Transform hitbox;
	public LayerMask joueur;

	void Update(){
    	if(gameObject.GetComponent<Ennemi>().pv<=0){
    		meurt();
    	}
    }

    void meurt(){
    	SceneManager.LoadScene("Congrats");
    }
	
	public void tourne()
	{
		Vector3 tourne = transform.localScale;
		tourne.z *= -1f;

		if (transform.position.x > player.position.x && estTourne)
		{
			transform.localScale = tourne;
			transform.Rotate(0f, 180f, 0f);
			estTourne = false;
		}
		else if (transform.position.x < player.position.x && !estTourne)
		{
			transform.localScale = tourne;
			transform.Rotate(0f, 180f, 0f);
			estTourne = true;
		}
	}

	public void coup(){
    		Collider2D[] touches =Physics2D.OverlapCircleAll(hitbox.position, 0.7f, joueur);
    		foreach(Collider2D joueur in touches){
    			joueur.GetComponent<Joueur>().prendDegats(3);
    		}
    }
}
