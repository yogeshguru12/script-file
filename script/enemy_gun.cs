using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_gun : MonoBehaviour
{
    public float Damge = 10;
    public float range = 100f;
    public ParticleSystem[] muzzel;
    public Transform gunbarrel;
    public TrailRenderer bullettrail;
    private float dir;
    private GameObject enemyShoot;
    // Start is called before the first frame update
    void Start()
    {
        enemyShoot = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        dir = Vector3.Distance(enemyShoot.transform.position, transform.position);
        if(dir <= range)
        {
            Shoot();
        }
    }
    void Shoot()
    {

       

       

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            foreach (var partical in muzzel)
            {
                partical.Emit(1);
            }
            if (hit.collider.tag=="Player")
            {
                var bullet = Instantiate(bullettrail, gunbarrel.position, Quaternion.identity);
                bullet.AddPosition(gunbarrel.transform.position);
                {
                    bullet.transform.position = transform.position + transform.forward * 8;
                }




                player_Health playerScript = hit.transform.GetComponent<player_Health>();
                {
                    playerScript.playerhealth(Damge);
                }
            }
            else
                return;


        }
        
    }
}
