using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMarche : StateMachineBehaviour
{
    public float vitesse= 2f;
    Transform player;
    Rigidbody2D rb;
    Boss boss;
    public float portee=2f;


    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        player= GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss= animator.GetComponent<Boss>();
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.tourne();
       Vector2 cible = new Vector2(player.position.x, rb.position.y);
       Vector2 nouvPos =Vector2.MoveTowards(rb.position, cible, vitesse*Time.fixedDeltaTime);
       rb.MovePosition(nouvPos);

      if(Vector2.Distance(player.position, rb.position) <= portee){
        animator.SetTrigger("coup");

      }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("coup");
   
    }

   
}
