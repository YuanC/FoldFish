using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalRotation : MonoBehaviour
{
    public float Speed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, Speed * Time.deltaTime, Space.World);
    }
}
