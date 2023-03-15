using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerpickup : MonoBehaviour

{ public float heal = 100f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player_Health health = other.GetComponent<player_Health>();
            {
                health.playerheal(heal);
            }
        }
        Destroy(this.gameObject);
    }
}
