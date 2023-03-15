using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public float affect = 10f;
    public float distance = 100f;
    public Transform cam;
    public ParticleSystem[] muzzle;
    public Transform gunbarrel;
    public TrailRenderer bullettrail;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            fire();
        }

    }
    void fire()
    {
        foreach (var partical in muzzle)
        {
            partical.Emit(1);
        }
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, affect))
            {
                if (hit.collider.tag == "enemy")
                {
                    if (hit.collider)
                    {
                        var bullet = Instantiate(bullettrail, gunbarrel.position, transform.rotation);
                        bullet.AddPosition(gunbarrel.transform.position);
                        {
                            bullet.transform.position = transform.position + transform.forward * 8;
                        }
                    }


                    enemyLives enemy = hit.transform.GetComponent<enemyLives>();
                    { enemy.life(affect); }

                }
            }
        }
    }
}
