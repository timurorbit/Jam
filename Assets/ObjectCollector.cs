using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollector : MonoBehaviour
{
    
    //todo change area with iterations
    public CircleCollider2D areaCollider;

    private void Start()
    {
        areaCollider = GetComponent<CircleCollider2D>();
    }

    public void Collect()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(areaCollider.transform.position, areaCollider.radius);
        
        Transform[] transforms = new Transform[colliders.Length];

        int index = 0;
        
        foreach (Collider2D collider in colliders)
        {
            transforms[index++] = collider.transform;
        }
        
        FindObjectOfType<oscillator>().toInstantiate = new List<Transform>(transforms);
    }
}
