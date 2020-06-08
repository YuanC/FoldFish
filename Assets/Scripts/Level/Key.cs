using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Door/Key logic
public class Key : MonoBehaviour
{
    public GameObject Door;

    void Start()
    {
        GetComponentInChildren<Renderer>().material.color = Door.GetComponentInChildren<Renderer>().material.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(Door);
        Destroy(gameObject);
    }
}
