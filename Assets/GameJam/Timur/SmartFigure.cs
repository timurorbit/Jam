using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartFigure : MonoBehaviour
{
    private List<SmartCollider> colliders;

    private void OnEnable()
    {
        colliders = new List<SmartCollider>(GetComponentsInChildren<SmartCollider>());
    }

    public void pushFigure(float force)
    {
        foreach (SmartCollider collider in colliders)
        {
            Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Calculate the direction vector from the child's position to (0,0,0)
                Vector2 directionToOrigin = Vector2.zero - rb.position;

                // Apply a force towards the origin
                rb.AddForce(directionToOrigin.normalized * force);
            }
        }
    }

    public void disableAllColliders()
    {
        List<SmartCollider> colliders = new List<SmartCollider>(GetComponentsInChildren<SmartCollider>());
        foreach (var smart in colliders)
        {
            smart.DisableMovement();
        }
    }
}
