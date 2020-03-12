using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIBehaviour : MonoBehaviour
{
    public TextMeshProUGUI ModeLabel;
    public TextMeshProUGUI ModeInstructions;

    public TextMeshProUGUI Instructions;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetFoldModeActive(bool isActive)
    {
        if (isActive)
        {
            ModeLabel.text = "Folding Mode";
            ModeInstructions.text = "Press [SPACE] to switch to Movement Mode";
            Instructions.text = "Click On Panels to Fold Them";
        }
        else
        {
            ModeLabel.text = "Movement Mode Mode";
            ModeInstructions.text = "Press [SPACE] to switch to Folding Mode";
            Instructions.text = "Move Fish with WASD and Arrow Keys\nMove Camera with Mouse";
        }
    }
}
