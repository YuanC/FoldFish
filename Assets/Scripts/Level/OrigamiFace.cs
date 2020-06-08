using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles the folding behaviour of each face
public class OrigamiFace : MonoBehaviour
{
    public List<EdgeWall> Edges;

    public string RotAxis;

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

            if (rotTimer > rotDuration) // If the target has been reached, set the angle to new value
            {
                moving = false;
                IsFolded = isFolded;

                if (String.Equals(RotAxis, "x"))
                {
                    transform.localRotation = Quaternion.Euler(targetRot, transform.rotation.y, transform.rotation.z);
                }
                else if (String.Equals(RotAxis, "y"))
                {
                    transform.localRotation = Quaternion.Euler(transform.rotation.x, targetRot, transform.rotation.z);
                }
                else if (String.Equals(RotAxis, "z"))
                {
                    transform.localRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, targetRot);
                }
            }
            else // Keep lerping
            {
                float angle = Mathf.LerpAngle(originalRot, targetRot, rotTimer);

                if (String.Equals(RotAxis, "x"))
                {
                    transform.localRotation = Quaternion.Euler(angle, transform.rotation.y, transform.rotation.z);
                }
                else if (String.Equals(RotAxis, "y"))
                {
                    transform.localRotation = Quaternion.Euler(transform.rotation.x, angle, transform.rotation.z);
                }
                else if (String.Equals(RotAxis, "z"))
                {
                    transform.localRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, angle);
                }
            }
        }
    }

    // Changes the position of the origami face
    public void ToggleFold() 
    {
        if (!moving)
        {
            moving = true;
            isFolded = !isFolded;
            rotTimer = 0f;
        }
    }
}
