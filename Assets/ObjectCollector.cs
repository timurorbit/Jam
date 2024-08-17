using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollector : MonoBehaviour
{
    [SerializeField]
    public CircleCollider2D[] levelColliders;

    [SerializeField] public LayerMask layerMask;
    
    public int levelIndex;

    private void Start()
    {
        
    }

    public void Collect()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(levelColliders[levelIndex].transform.position, levelColliders[levelIndex].radius, layerMask);
        
        Transform[] transforms = new Transform[colliders.Length];

        int index = 0;
        
        foreach (Collider2D collider in colliders)
        {
            if (collider.GetComponent<SmartCollider>())
            {
                transforms[index++] = collider.transform;   
            }
        }
        
        FindObjectOfType<oscillator>().toInstantiate = new List<Transform>(transforms);

        levelIndex++;
    }
}
