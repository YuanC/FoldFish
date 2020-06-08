using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Handles the UI per level upon switching between folding and movement modes
public class UIBehaviour : MonoBehaviour
{
    public TextMeshProUGUI ModeInstructions;
    public TextMeshProUGUI Instructions;
    public GameObject UIOutline;

    public void SetFoldModeActive(bool isActive)
    {
        if (isActive)
        {
            Cursor.visible = true;
            UIOutline.SetActive(true);
            ModeInstructions.text = "Press [SPACE] for camera/fish movement";
            Instructions.text = "Click On Panels to Fold Them";
        }
        else
        {
            Cursor.visible = false;
            UIOutline.SetActive(false);
            ModeInstructions.text = "Press [SPACE] to switch to folding mode";
            Instructions.text = "Move Fish with WASD/Arrow Keys\nMove Camera with Mouse";
        }
    }
}
