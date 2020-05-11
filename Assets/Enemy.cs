
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 50f;
    public void TakeDamage(float amount) //will be called by Gun class
    {
        health -= amount;

        //If health less than or equal to than 0, then dies
        if(health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
