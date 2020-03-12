using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationManager : MonoBehaviour
{
    private List<EdgeWall> teleportEdges = new List<EdgeWall>();


    // Start is called before the first frame update
    void Start()
    {
        teleportEdges.AddRange(GetComponentsInChildren<EdgeWall>());
    }

    public void SetEdges(bool isActive)
    {
        foreach (EdgeWall edge in teleportEdges)
        {
            //edge.SetActive(isActive);
        }
    }
}
