using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextScreen : MonoBehaviour
{
    public float timer;
    public string NextSceneName;

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            if (!String.IsNullOrWhiteSpace(NextSceneName))
            {
                if (Input.GetKeyDown(KeyCode.Space) ||
                    Input.GetKeyDown(KeyCode.Return) ||
                    Input.GetMouseButtonDown(0) ||
                    Input.GetMouseButtonDown(1))
                SceneManager.LoadScene(NextSceneName);
            }
            else
            {
                Application.Quit();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
