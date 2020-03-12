using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public FishMovement fishMovement;
    public UIBehaviour uiBehaviour;

    public bool isFoldMode = false;

    public float DistanceFromOrigin = 11f;
    public float MouseSensitivity = 10f;
    public Vector3 RotateTarget = new Vector3(0,0,0);

    // Start is called before the first frame update
    void Start()
    {
        uiBehaviour.SetFoldModeActive(isFoldMode);
    }

    // Update is called once per frame
    void Update()
    {
        // Changes Input Mode
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isFoldMode = !isFoldMode;
            uiBehaviour.SetFoldModeActive(isFoldMode);
        }

        // Handles Input Logic
        fishMovement.enabled = !isFoldMode;

        if (isFoldMode) // Control Origami Figure
        {
            Cursor.visible = true;

            if (Input.GetMouseButtonDown(0)) // User clicks on a panel
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Debug.Log("Raycast");

                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    OrigamiFace oFace = hit.transform.GetComponentInParent<OrigamiFace>();
                    oFace?.ToggleFold();
                }
            }
        }
        else // Control Fish And Camera
        {
            Cursor.visible = false;

            float mouseDeltaX = Input.GetAxisRaw("Mouse X");
            transform.RotateAround(RotateTarget, Vector3.up, mouseDeltaX * MouseSensitivity);

            transform.LookAt(Vector3.zero);
        }
    }

}
