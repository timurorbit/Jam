using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexMovement : MonoBehaviour{
   [SerializeField] private float speed;
   private void Update(){
      // Get the position of the center of the screen
      Vector2 centerPosition = Vector2.zero; // Assuming the center is (0, 0)
        
      // Calculate the direction towards the center
      Vector2 direction = (centerPosition - (Vector2)transform.position).normalized;
        
      // Move the object towards the center
      transform.position = Vector2.MoveTowards(transform.position, centerPosition, speed * Time.deltaTime);
   }
}
