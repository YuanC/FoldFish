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
            FishCloner.PairedHandler = pair != null ? pair.FishCloner : null;
            ActiveWallObjects.SetActive(pair == null);
            InactiveWallObjects.SetActive(pair != null);
        }
    }

    public FishCloneHandler FishCloner { get; set; }
    public Collider CloneTrigger;

    public Collider TeleportationTrigger;
    public GameObject ActiveWallObjects;
    public GameObject InactiveWallObjects;

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
