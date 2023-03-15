using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSwitch : MonoBehaviour
{
    public GameObject Thirdcam;
    public GameObject Firstcam;
    public GameObject gunMode;
    public int CamMode;
    public GameObject point;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Q"))
        {
            if (CamMode == 1)
            {
                CamMode = 0;
            }
            else
            {
                CamMode += 1;
            }
        }
        StartCoroutine(CameraChange());
    }
    IEnumerator CameraChange()
    {
        yield return new WaitForSeconds(0.0f);
        if (CamMode == 0)
        {
            
            Thirdcam.SetActive(true);
            Firstcam.SetActive(false);
           
            gunMode.SetActive(false);
        }
        if (CamMode == 1)
        {
            Thirdcam.SetActive(false);
            Firstcam.SetActive(true);
          
            gunMode.SetActive(true);

        }
    }
}
