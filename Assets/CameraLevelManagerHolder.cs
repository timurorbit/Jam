using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
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

    [SerializeField] public List<GameObject> borders;

    [SerializeField]
    public AudioClip sizeSound;

    private CameraLevelManager holder;

    private int numberOfEnemies;
    
    public int NumberOfEnemies
    {
        get { return numberOfEnemies; }
        set
        {
            numberOfEnemies = value;
            if (numberOfEnemies == 0)
            {
                MMSoundManagerPlayOptions options = MMSoundManagerPlayOptions.Default;
                options.Persistent = true;
                MMSoundManagerSoundPlayEvent.Trigger(sizeSound, options);
                holder.launchNextLevel();
            }
        }
    }

    private void OnEnable()
    {
        managerParams();
    }

    public void managerParams()
    {
        holder = FindObjectOfType<CameraLevelManager>();
        holder.cameras = cameras;
        holder.defaultCamera = defaultCamera;
        holder.Levels = Levels;
        holder.Coalas = Coalas;
        holder.theirPositions = theirPositions;
        holder.Enemies = Enemies;
        holder.borders = borders;
        holder.recreateLevel();
    }
}
