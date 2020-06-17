using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Keeps track of score, life, and death (of player)
public class GameManager : MonoBehaviour
{
    //Singleton since we should have only 1 game manager in the game
    public static GameManager instance;

    public int lifeScore;
    public bool isPlayerDead;

    //First method called
    void Awake()
    {
        GetInstance();
    }

    public void GetInstance()
    {
        if(instance != null) //Meaning a gamemanager was already created, then destroy the new gameobject created
        {
            Destroy(gameObject);
        }
        else //we don't have a copy of game manager
        {
            instance = this; //this refers to the GameManager class
            DontDestroyOnLoad(gameObject); //Predefined method in unity: An Object not destroyed on Scene change. The GameManager does not get destroyed when changing between scenes
            //Note: The load of a new scene destroys all current scene object, but calling DontDestroyOnLoad preserves that object.
        }
    }

    public void SetDamage(float damage)
    {
        Debug.Log("Damage");
    }
}
