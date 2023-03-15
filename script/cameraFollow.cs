using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{

    public float moveSmooth;
    public float turnSmooth;
    public Vector3 moveOffSet;
    public Vector3 rotOffSet;
    public Transform target;

    private void FixedUpdate()
    {
        Follow();
    }
    void Follow()
    {
        HandleMove();
        handelRot();
    }
    void HandleMove()
    {
        Vector3 Targetpos = new Vector3();
        Targetpos = target.TransformPoint(moveOffSet);
        transform.position = Vector3.Lerp(transform.position, Targetpos, moveSmooth * Time.deltaTime);
    }
    void handelRot()
    {
        var direction = target.position - transform.position;
        var Rotation = new Quaternion();
        Rotation = Quaternion.LookRotation(direction + rotOffSet, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, Rotation, turnSmooth * Time.deltaTime);
    }

}

