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

    // Cursor Stuffs
    public Texture2D CursorDefault;
    public Texture2D CursorHover;
    private Vector2 cursorHotspot;

    // Start is called before the first frame update
    void Start()
    {
        cursorHotspot = new Vector2(CursorDefault.width, CursorDefault.height);
        Cursor.SetCursor(CursorDefault, Vector2.zero, CursorMode.Auto);
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
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                OrigamiFace oFace = hit.transform.GetComponentInParent<OrigamiFace>();

                Cursor.SetCursor((oFace ? CursorHover : CursorDefault), cursorHotspot, CursorMode.Auto);

                if (Input.GetMouseButtonDown(0)) // User clicks on a panel
                {
                    oFace?.ToggleFold();
                }
            }
            else
            {
                Cursor.SetCursor(CursorDefault, cursorHotspot, CursorMode.Auto);
            }
        }
        else // Control Fish And Camera
        {
            Cursor.visible = false;

            float mouseDeltaX = Input.GetAxisRaw("Mouse X");
            transform.RotateAround(RotateTarget, Vector3.up, mouseDeltaX * MouseSensitivity);

            float mouseDeltaY = Input.GetAxisRaw("Mouse Y");
            transform.RotateAround(RotateTarget, Vector3.right, -mouseDeltaY * MouseSensitivity);
            
            transform.LookAt(Vector3.zero);
        }
    }

}
