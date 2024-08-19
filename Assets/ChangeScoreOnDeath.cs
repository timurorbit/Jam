using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.TopDownEngine;
using UnityEngine;

public class ChangeScoreOnDeath : MonoBehaviour
{
    private CameraLevelManagerHolder cameraLevelManager;
    private void OnEnable()
    {
        cameraLevelManager = FindObjectOfType<CameraLevelManagerHolder>();
        if (cameraLevelManager)
        {
            cameraLevelManager.NumberOfEnemies++;
        }
        GetComponent<Health>().OnDeath += decreaseEnemiesNumber;
    }

    private void decreaseEnemiesNumber()
    {
        cameraLevelManager.NumberOfEnemies--;
    }
}
