using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class player_Health : MonoBehaviour
{
    public float lifemax = 10;
    public float lifecurrent= 10;
    public Slider healthbar;
    public GameObject losspanel;
    
    [Header("damer")]
    public Color damColor;
    public Image damerImage;
    float colorSmoothimg = 6f;
    bool istakingdamer=false;
    private void Start()
    {
        lifecurrent = lifemax;
    }
    public void playerhealth(float deathline)
    {
        istakingdamer = true;
        lifecurrent -= deathline;
        if (lifecurrent <= 0f)
        {
            
            Die();
        }

    }
    void Die()
    {
        losspanel.SetActive(true);
        Destroy(gameObject);
    }
    private void Update()
    {

        if (istakingdamer)
        {
            damerImage.color = damColor;
        }
        else
        {
            damerImage.color=Color.Lerp(damerImage.color,Color.clear,colorSmoothimg*Time.deltaTime);
        }
        istakingdamer = false;

        healthbar.value = lifecurrent;
      


    }

    public void playerheal(float heallife)
    {
        if (lifecurrent < lifemax)
        {
            lifecurrent += heallife;
            if (lifecurrent > lifemax)
            {
                lifecurrent = lifemax;
            }
               
        }
      
    }

}

