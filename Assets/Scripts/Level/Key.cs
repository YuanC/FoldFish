using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject Door;

    // Start is called before the first frame update
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
