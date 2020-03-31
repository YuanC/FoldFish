using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrigamiManager : MonoBehaviour
{
    public List<OrigamiFace> faces = new List<OrigamiFace>();

    //public TeleportationManager teleportationManager;

    // Start is called before the first frame update
    void Start()
    {
        // Get list of origami faces
        faces.AddRange(GetComponentsInChildren<OrigamiFace>());
    }

    // Update is called once per frame
    void Update()
    {
        // Only for level 1
        if (faces[0].IsFolded && faces[1].IsFolded)
        {
            EdgeWall.PairWalls(faces[0].Edges[0], faces[1].Edges[0]);
        }
        else
        {
            faces[0].Edges[0].Pair = null;
            faces[1].Edges[0].Pair = null;
        }
    }
}
