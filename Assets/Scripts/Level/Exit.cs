using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
