using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartCollider : MonoBehaviour
{
    public string layerName = "ReadyHoney";
    private float speed = 500f; 
    private void OnTriggerEnter2D(Collider2D other)
    {
        DisableMovement();

        SmartFigure smartFigure = GetComponentInParent<SmartFigure>();
        if (smartFigure)
        {
            smartFigure.disableAllColliders();
        }
    }

    public void DisableMovement()
    {
        GetComponent<PolygonCollider2D>().isTrigger = true;
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        if (rigidbody2D)
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;  
        }
        
    }
    
    private void OnEnable(){
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Calculate the direction vector from the child's position to (0,0,0)
            Vector2 directionToOrigin = Vector2.zero - rb.position;

            // Apply a force towards the origin
            rb.AddForce(directionToOrigin.normalized * speed);
        }
    }

    // private void OnCollisionEnter2D(Collision other)
    // {
    //     GetComponent<SphereCollider>().isTrigger = true;
    //     Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
    //     rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
    // }
}
