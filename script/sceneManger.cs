using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManger : MonoBehaviour
{

    public int index;
    public void changescene()
    {
        SceneManager.LoadScene(index);
    }
}
