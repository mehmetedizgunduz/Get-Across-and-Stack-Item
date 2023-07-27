using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovementLeftSpeedUp : MonoBehaviour
{
    public float speed = 15;
    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
}
