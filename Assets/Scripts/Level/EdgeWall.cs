using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeWall : MonoBehaviour
{
    private EdgeWall pair;
    public EdgeWall Pair
    {
        get { return pair; }
        set
        {
            pair = value;

            // Assign paired fishcloners
            if (pair != null)
            {
                FishCloner.PairedHandler = pair.FishCloner;
                WallCollider.enabled = false;
            }
            else
            {
                FishCloner.PairedHandler = null;
                WallCollider.enabled = true;
            }
        }
    }

    public FishCloneHandler FishCloner { get; set; }
    public Transform PivotPoint;

    public Collider TeleportationTrigger;
    public Collider WallCollider;

    // Start is called before the first frame update
    void Start()
    {
        FishCloner = GetComponentInChildren<FishCloneHandler>();
    }

    // Helper function to pair walls
    public static void PairWalls(EdgeWall wall1, EdgeWall wall2)
    {
        wall1.Pair = wall2;
        wall2.Pair = wall1;
    }
}
