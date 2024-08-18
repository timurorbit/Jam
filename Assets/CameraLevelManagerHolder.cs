using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLevelManagerHolder : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> Levels;

    [SerializeField] public List<GameObject> cameras;
    [SerializeField] public GameObject defaultCamera;

    [SerializeField] public List<GameObject> Coalas;
    [SerializeField] public List<Transform> theirPositions;


    [SerializeField] public List<GameObject> Enemies;

    private void OnEnable()
    {
        managerParams();
    }

    public void managerParams()
    {
        CameraLevelManager holder = FindObjectOfType<CameraLevelManager>();
        holder.cameras = cameras;
        holder.defaultCamera = defaultCamera;
        holder.Levels = Levels;
        holder.Coalas = Coalas;
        holder.theirPositions = theirPositions;
        holder.Enemies = Enemies;
        holder.recreateLevel();
    }
}
