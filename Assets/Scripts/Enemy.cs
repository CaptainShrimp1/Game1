using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update


    private Transform target;
    // скорость вращения
    public float rotationSpeed = 1F;
    //мертвая зона вращения (чтобы турель не дергалась при x=0)
    public float deadZone = 0.1F;
    //направление вращения ( "0" - не вращать, "1" - вправо и "-1" - влево)
    private float rotateDirection = 0;
    void Start()
    {
        target = GameObject.Find("Player").transform;
    }


    void LateUpdate()
    {

        if (transform.InverseTransformPoint(target.position).x > deadZone / 2) rotateDirection = -1F;
        else if (transform.InverseTransformPoint(target.position).x < -deadZone / 2) rotateDirection = 1F;
        else
        {
            if (transform.InverseTransformPoint(target.position).y < 0) rotateDirection = 1F;
            else rotateDirection = 0;
        }

        transform.rotation *= Quaternion.Euler(0, 0, rotationSpeed * rotateDirection);
    }
}