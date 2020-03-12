using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCloneHandler : MonoBehaviour
{
    public FishCloneHandler PairedHandler;
    public Vector3 CloneOriginPoint;
    public GameObject ClonePrefab;

    private GameObject Clone;
    private Vector3 wallPosition;

    private void Start()
    {
        //wallPosition = GetComponentInParent();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "player")
        {
            if (PairedHandler) // If the edge is paired
            {
                if (!Clone) // Add clone instance if pairs are established
                {
                    //Vector3 clonePos = other.transform.position - 
                    //Instantiate(ClonePrefab, , Vector3 position, Quaternion rotation, Transform parent);
                }

                // TODO: Update clone position/rotation to match that of real fishy
            }
            else // Delete clone instance pairs are deleted
            {
                if (Clone != null)
                {
                    Destroy(Clone);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Destroy clone instance
        if (other.tag == "player")
        {
            if (Clone != null)
            {
                Destroy(Clone);
            }
        }
    }
}
