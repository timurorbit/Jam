using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNextCameraLevel : MonoBehaviour
{
    public void nextLevelClick()
    {
        FindObjectOfType<CameraLevelManager>().launchNextLevel();
    }

    public void diedClick()
    {
        FindObjectOfType<CameraLevelManager>().died();
    }
}
