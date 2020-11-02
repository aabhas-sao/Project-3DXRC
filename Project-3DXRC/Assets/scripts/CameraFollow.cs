using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public Vector3 offset;
    public Vector3 eulerRotation;
    public float damper;

    void Start()
    {
        transform.eulerAngles = eulerRotation;
    }

    void FixedUpdate()
    {
        if(Target == null)
            return;

        transform.position = Vector3.Lerp(transform.position, Target.position + offset, damper);
        transform.LookAt(Target);
    }
}
