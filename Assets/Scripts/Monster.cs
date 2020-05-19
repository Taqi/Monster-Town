using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public GameObject player; //What the monster will target
    private NavMeshAgent nav; //Component inside the Monster Object

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //Walk towards player
        nav.SetDestination(player.transform.position);
        
    }
}
