using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Joueur : MonoBehaviour{
	private Rigidbody2D rb;
	public Animator animateur;
	public int pvMax=5;
	public int pv;
	

	[Header("Marche et Course")]
	private float vitesse = 3;   
    private float vitesseMax =6f;
    private float vitesseMin=3;

	
	//saut
	[Header("Saut")]
    private bool auSol = false;
    public Transform checkSol;
    public float facteurChute = 3f; 
	private float facteurLowSaut = 2f;
    private float angleSol = 0.05f;
    public LayerMask coucheSol;
    private float detente = 8;
    //attque
    [Header("Attaque")]
    public Transform hitbox;
    public Transform pointtir;
    private int attaque= 5;
    public float portee =0.5f;
    public LayerMask coucheEnnemi;
    public GameObject projectile;
    public Vie vie;
    public float tpsInvu =1.5f;
    private bool invulnerable=false;
    public float coolDownCoup=0.8f;
    public float coolDownTir=0.9f;
    private float nextCoup=0;
    private float nextTir=0;

    // Start is called before the first frame update
    void Start(){
    	pv=pvMax;
        rb= GetComponent<Rigidbody2D>(); 
        vie.SetVieMax(pvMax);
    }

    // Update is called once per frame
    void Update(){
    	
        marche();
        verifSol();
        if (Input.GetKeyDown(KeyCode.Space)){
    		saut();
    	}
        superSaut();
        if (Input.GetKeyDown(KeyCode.W)){
    		coup();
    	}
    	if (Input.GetKeyDown(KeyCode.X)){
    		tir();
    	}
        animateur.SetFloat("vitesse", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
        
        
    }

    void coup(){
    	if(Time.time>nextCoup){
    		animateur.SetTrigger("coup");
    		Collider2D[] touches =Physics2D.OverlapCircleAll(hitbox.position, portee, coucheEnnemi);
    		foreach(Collider2D ennemi in touches){
    			ennemi.GetComponent<Ennemi>().prendDegats(attaque);
    		}
            nextCoup=Time.time+coolDownCoup;
        }
            
    	
    }

    void tir(){
        if(Time.time>nextTir){
           animateur.SetTrigger("tir");
           Instantiate(projectile, pointtir.position, GetComponent<Transform>().rotation);
           nextTir=Time.time+coolDownTir;
        }

    }

    public void prendDegats(int degats){

    	if(!invulnerable){
	    	
	    	pv-=degats;
	    	vie.SetVie(pv);

	    	if(pv<=0){
	    		Meurt();
	    	}
	    	StartCoroutine(Touche());
	    }
    }

    IEnumerator Touche(){
    	invulnerable=true;
    	Color tmp = gameObject.GetComponent<SpriteRenderer>().color;
		tmp.a = 0.5f;
		gameObject.GetComponent<SpriteRenderer>().color = tmp;
    	yield return new WaitForSeconds(tpsInvu);
    	Color tmp2 = gameObject.GetComponent<SpriteRenderer>().color;
		tmp2.a = 1f;
		gameObject.GetComponent<SpriteRenderer>().color = tmp2;
    	invulnerable = false;

    }

    public void Meurt(){

    	SceneManager.LoadScene("GameOver");

    }

    void accroupi(){
        /*if (Input.GetKeyDown("down"))
        {
            GetComponent<BoxCollider2D>().transform.localScale
        }*/
    }

    void saut(){
        if (Input.GetKeyDown(KeyCode.Space)&& auSol){
        	animateur.SetTrigger("saut");
            rb.velocity = new Vector2(rb.velocity.x, detente);        
        }
        
    }

    void superSaut() {
	    if (rb.velocity.y < 0) {
	        rb.velocity += Vector2.up * Physics2D.gravity * (facteurChute - 1) * Time.deltaTime;
	    } 
	    else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space)) {
	        rb.velocity += Vector2.up * Physics2D.gravity * (facteurLowSaut - 1) * Time.deltaTime;
	    }   
	}

	void course(){
		if(Input.GetKey(KeyCode.C)&& auSol && vitesse<=vitesseMax ){
    			vitesse+=0.1f;

    	}
    	else if(/*Input.GetKeyUp(KeyCode.C)&&*/auSol && vitesse>vitesseMin){
    			vitesse-=0.1f;
    	}
	}

    void marche(){
    	
    	
		if (Input.GetKeyDown("left")){
			this.gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
		}
		if (Input.GetKeyDown("right")){
			this.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
		}
	     

	    course();
  
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * (vitesse);
        rb.velocity = new Vector2(moveBy, rb.velocity.y);
       
    }

    void verifSol(){
        Collider2D hitbox = Physics2D.OverlapCircle(checkSol.position, angleSol, coucheSol);
        if (hitbox != null)
        {
            auSol = true;
        }
        else
        {
            auSol = false;
        }
    }

    void OnDrawGizmosSelected(){
    	if(hitbox==null){
    		return;
    	}
    	Gizmos.DrawWireSphere(hitbox.position, portee);
    	
    }
}
