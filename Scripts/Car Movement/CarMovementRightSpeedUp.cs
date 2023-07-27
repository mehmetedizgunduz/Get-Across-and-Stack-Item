using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovementRightSpeedUp : MonoBehaviour
{
    public float speed = 15;
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
