using System.Collections;
using UnityEngine; 

// Creates a clone fish sprite for continuous movement between portals
// Activates if the fish is close to the portal
public class FishCloneHandler : MonoBehaviour
{
    public FishCloneHandler PairedHandler;
    public GameObject ClonePrefab;
    public EdgeWall Edge;

    private GameObject Clone;
    private Vector3 wallPosition;

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (PairedHandler) // If the edge is paired
            {
                // Check if fish has passed the teleportation thingy
                FishMovement fishMov = other.GetComponentInParent<FishMovement>();
                Vector3 fishDelta = Edge.transform.InverseTransformPoint(fishMov.transform.position);

                Vector3 reflectedDelta = Vector3.Reflect(fishDelta, Vector3.up);
                Debug.Log(fishDelta.normalized);
                Debug.Log(reflectedDelta.normalized);
                Transform pairedTrans = PairedHandler.GetComponentInParent<EdgeWall>().transform;
                Vector3 newPos = pairedTrans.TransformPoint(reflectedDelta);

                // Teleport that fish if the boundary is crossed!
                if (fishDelta.y < -0.01)
                {
                    fishMov.transform.position = newPos;
                }
                else // Create/update clone
                {
                    if (!Clone) // Add clone instance if pairs are established
                    {
                        Clone = Instantiate(ClonePrefab, newPos, fishMov.GetComponentInChildren<SpriteRenderer>().transform.rotation);
                    }
                    else
                    {
                        Clone.transform.position = newPos;
                        Clone.GetComponentInChildren<SpriteRenderer>().transform.rotation = fishMov.GetComponentInChildren<SpriteRenderer>().transform.rotation;
                    }
                }
            }
            else // Delete clone instance as pairs are deleted
            {
                if (Clone != null)
                {
                    Destroy(Clone);
                }
            }
        }
    }

    public void Deactivate()
    {
        if (Clone != null)
        {
            Destroy(Clone);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        // Destroy clone instance
        if (other.tag == "Player")
        {
            if (Clone != null)
            {
                Destroy(Clone);
            }
        }
    }
}
