using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyLives : MonoBehaviour
{
    public float lifeline = 10f;
    public Slider healthbar;
    public GameObject healthpack;
    public GameObject deatheffect;

    public void life(float deathline)
    {
        lifeline -= deathline;
        if (lifeline <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        GameObject health = Instantiate(healthpack,transform.position,transform.rotation);
        GameObject effect = Instantiate(deatheffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    private void Update()
    {
        healthbar.value = lifeline;
    }

    
}
