using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public float Speed = 1f;

    private Transform spriteTransform;

    // Start is called before the first frame update
    void Start()
    {
        spriteTransform = GetComponentInChildren<SpriteRenderer>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal");
        float deltaY = Input.GetAxis("Vertical");

        transform.position += new Vector3(deltaX * Time.deltaTime * Speed, deltaY * Time.deltaTime * Speed, 0);

        if (deltaX != 0.0f || deltaY != 0.0f)
        {
            spriteTransform.localRotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg*Mathf.Atan2(deltaY, deltaX));
        }
    }
}
        
