using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update


    private Transform target;
    // �������� ��������
    public float rotationSpeed = 1F;
    //������� ���� �������� (����� ������ �� ��������� ��� x=0)
    public float deadZone = 0.1F;
    //����������� �������� ( "0" - �� �������, "1" - ������ � "-1" - �����)
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