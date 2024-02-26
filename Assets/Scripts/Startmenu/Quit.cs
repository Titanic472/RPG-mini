using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public void QuitGame()
    {   
        Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow);
        Application.Quit();
    }

    void OnApplicationQuit()
    {
        Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow);
    }
}
