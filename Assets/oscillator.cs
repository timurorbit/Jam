using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oscillator : MonoBehaviour{
    private float timeCounter = 0;
    [SerializeField] private float speed;
    [SerializeField] private float radius;
    [SerializeField] private  float angle;
    [SerializeField] private GameObject hexagonPref;

    
    void Update(){
        timeCounter += Time.deltaTime * speed;
        float x = Mathf.Cos(timeCounter) * radius;
        float y = Mathf.Sin(timeCounter) * radius;
        transform.position = new Vector3(x, y);
        
        float rotationAngle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        
        // Apply the rotation to the object
        transform.rotation = Quaternion.Euler(0, 0, rotationAngle);
        if (Input.GetKeyDown("a")){
            Instantiate(hexagonPref, transform.position, Quaternion.identity);
        }
    }
}
