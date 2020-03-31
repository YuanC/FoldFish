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
            if (value != null)
            {
                FishCloner.PairedHandler = pair.FishCloner;
                ActiveWallObjects.SetActive(true);
                InactiveWallObjects.SetActive(false);
            }
            else
            {
                FishCloner.PairedHandler = null;
                FishCloner.Deactivate();
                ActiveWallObjects.SetActive(false);
                InactiveWallObjects.SetActive(true);
            }
        }
    }

    public FishCloneHandler FishCloner { get; set; }

    public GameObject ActiveWallObjects;
    public GameObject InactiveWallObjects;

    // Start is called before the first frame update
    void Start()
    {
        FishCloner = GetComponentInChildren<FishCloneHandler>();
        Pair = null;
    }

    // Helper function to pair walls
    public static void PairWalls(EdgeWall wall1, EdgeWall wall2)
    {
        wall1.Pair = wall2;
        wall2.Pair = wall1;
    }
}
