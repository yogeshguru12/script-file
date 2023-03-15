using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinCollect : MonoBehaviour
{
    private int apple;
    public Text applesText;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            Destroy(collision.gameObject);
            apple++;

            applesText.text = " " + apple;
        }
    }
}
