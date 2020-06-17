using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public GameObject playerObject; //What the monster will target
    public Transform player;
    private NavMeshAgent nav; //Component inside the Monster Object

    static Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - this.transform.position; 
        float angle = Vector3.Angle(direction, this.transform.forward); //Angle between player and direction

        //If player is within 20 distance of the monster
        if(Vector3.Distance(player.position, this.transform.position) < 20 && angle <45)
        {
            direction.y = 0; //y direction of monster stays 0 so he doesnt fall when we get too close

            //Rotation angle when monster looks at us
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            //When monster is within 10 distance, set the isIdle parameter to false
            anim.SetBool("isIdle", false);

            //If line (direction magnitude) between monster and player is greater than 5. Then monster moves toward us
            if(direction.magnitude > 5)
            {
                this.transform.Translate(0, 0, 0.05f); //Z direction is 0.05, which is the forward axis (blue one) of the monster
                anim.SetBool("isWalking", true); //If within 5 distance than set to true
                anim.SetBool("isAttacking", false);

                //Walk towards player
                //nav.SetDestination(playerObject.transform.position);
            }
            else
            {
                anim.SetBool("isWalking", false);
                anim.SetBool("isAttacking", true);
            }

        }
        
        else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", false);
        }

        
    }

    // (Animation event) Method gets called when Attack animation hits the target
    public void AttackEnd()
    {
        //Send damage to the player
        //PlayerMovement.Instance.OnHit(this.gameobject, 25);
        //PlayerMovement.Instance.DoDeadByDamage("Dying");
    }
}
