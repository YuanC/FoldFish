using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    // Context for connecting the edges upon folding
    void Update()
    {
        // Only for level 1

        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "Level1")
        {
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
        else if (sceneName == "Level2")
        {
            if (faces[0].IsFolded &&
                faces[1].IsFolded &&
                faces[2].IsFolded &&
                faces[3].IsFolded &&
                faces[4].IsFolded &&
                faces[5].IsFolded &&
                faces[6].IsFolded)
            {
                EdgeWall.PairWalls(faces[2].Edges[0], faces[6].Edges[0]);
            }
            else
            {
                EdgeWall.UnPairWalls(faces[2].Edges[0], faces[6].Edges[0]);
            }
        }
    }
}
