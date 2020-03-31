using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrigamiManager : MonoBehaviour
{
    public List<EdgeWall> teleportEdges = new List<EdgeWall>();
    private List<OrigamiFace> faces = new List<OrigamiFace>();

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
        bool allFacesFolded = true;

        // Check if origami faces are folded, and update as necessary
        foreach(OrigamiFace face in faces)
        {
            if (face.IsFolded == false)
            {
                allFacesFolded = false;
                break;
            }
        }

        // Set the stuff to whatever
        //teleportationManager.SetEdges(allFacesFolded);
    }
}
