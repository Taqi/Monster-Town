
using UnityEngine;

public class Gun : MonoBehaviour
{
    //Damage of Gun
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;
    public float fireRate = 15f;
    public float nextTimeToFire = 0f; //Time needed before user can shoot with gun again

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;

    //Reference it as GameObject, so we can instantiate in the scene
    public GameObject impactEffect;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        //Only play muzzle flash (particle system of gun) when shooting
        muzzleFlash.Play();

        //RaycastHit is a variable that stores information on what our ray hits
        RaycastHit hitInfo;

        //Physics.Raycast returns true if we hit something, false otherwise
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitInfo, range)) //arguments (Shoot from the position of our camera, shoot towards direction we are facing, out hit will give all the information on what we hit (Unity does that), range of where we can shoot
        {
            //hitInfo.transform.name gives us the name of what we hit
            Debug.Log(hitInfo.transform.name);

            Enemy enemy =  hitInfo.transform.GetComponent<Enemy>(); //Call Enemy class here
            //Note: not all objects we hit will have an Enemy script on them (ex: we might hit an environment piece)

            //Check if found an Enemy component
            if(enemy != null)
            {
                enemy.TakeDamage(damage); //Method of Enemy class
            }

            //Give some push to the object when shooting it (object must have a rigid body)
            if(hitInfo.rigidbody != null)
            {
                //Add a force to the normal direction (negative for backwards direction) * more force
                hitInfo.rigidbody.AddForce(-hitInfo.normal * impactForce);
            }

            //Only want to have bullet impact effect if it hits something (so we put it inside this if statement)
            GameObject impact = Instantiate(impactEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            Destroy(impact, 2f); //Destroy after 2 seconds
        }
    }
}
