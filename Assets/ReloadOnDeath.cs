using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.TopDownEngine;
using UnityEngine;

public class ReloadOnDeath : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<Health>().OnDeath += () =>
        {
            StartCoroutine(FindObjectOfType<CameraLevelManager>().died());
        };
    }
}
