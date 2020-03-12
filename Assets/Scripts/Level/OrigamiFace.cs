using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// FoldingBehaviour
public class OrigamiFace : MonoBehaviour
{
    public bool IsFolded;
    private bool isFolded;

    private bool moving = false;
    private float rotDuration = 1f;
    private float rotTimer = 0f;

    public List<float> rotations = new List<float>(2); // [0] is unfolded, [1] is folded

    void Start()
    {
        isFolded = false;
        IsFolded = false;
    }

    void Update()
    {
        if (moving) // Animate the fold toward the new position
        {
            rotTimer += Time.deltaTime;

            float targetRot = isFolded ? rotations[1] : rotations[0];
            float originalRot = isFolded ? rotations[0] : rotations[1];

            // If the target has been reached.
            if (rotTimer > rotDuration)
            {
                moving = false;
                IsFolded = isFolded;

                transform.rotation = Quaternion.Euler(transform.rotation.x, targetRot, transform.rotation.z);
            }
            else
            {
                float angle = Mathf.LerpAngle(originalRot, targetRot, rotTimer);

                transform.rotation = Quaternion.Euler(transform.rotation.x, angle, transform.rotation.z);
            }
        }
    }

    public void ToggleFold() // Changes the position of the origami face
    {
        if (!moving)
        {
            moving = true;
            isFolded = !isFolded;
            rotTimer = 0f;
        }
    }
}
