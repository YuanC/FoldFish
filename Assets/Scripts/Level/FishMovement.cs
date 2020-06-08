using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public float Speed = 1f;

    private Transform spriteTransform;

    void Start()
    {
        spriteTransform = GetComponentInChildren<SpriteRenderer>().transform;
    }

    void Update()
    {
        // Moves based on input
        float deltaX = Input.GetAxis("Horizontal");
        float deltaY = Input.GetAxis("Vertical");

        transform.position += new Vector3(deltaX * Time.deltaTime * Speed, deltaY * Time.deltaTime * Speed, 0);

        // Update rotation
        if (deltaX != 0.0f || deltaY != 0.0f)
        {
            spriteTransform.localRotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg*Mathf.Atan2(deltaY, deltaX));
        }
    }
}
        
