using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Proceeds to next level or quits
public class Exit : MonoBehaviour
{
    public string NextLevelName;

    private void OnTriggerEnter(Collider other)
    {
        if (string.IsNullOrWhiteSpace(NextLevelName))
        {
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene(NextLevelName);
        }
    }
}
