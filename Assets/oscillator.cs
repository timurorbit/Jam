using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oscillator : MonoBehaviour
{
    private float timeCounter = 0;
    [SerializeField] private float speed;
    [SerializeField] private float radius;
    [SerializeField] private float angle;
    [SerializeField] private GameObject hexagonPref;
    [SerializeField] private int pushesToCycle = 5;

    [SerializeField] private GameObject empty;
    public List<Transform> toInstantiate;

    private int pushes;
    private int iteration;


    void Update()
    {
        timeCounter += Time.deltaTime * speed;
        float x = Mathf.Cos(timeCounter) * radius;
        float y = Mathf.Sin(timeCounter) * radius;
        transform.position = new Vector3(x, y);

        float rotationAngle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;

        // Apply the rotation to the object
        transform.rotation = Quaternion.Euler(0, 0, rotationAngle);
        if (Input.GetKeyDown("a"))
        {
            pushFigure();
        }
    }

    private void pushFigure()
    {
        createFigure();
        pushes++;
        if (pushes % pushesToCycle == 0)
        {
            nextlevel();
        }
    }

    private void createFigure()
    {
        if (iteration == 0)
        {
            Instantiate(hexagonPref, transform.position, Quaternion.identity);
        }
        else
        {
            GameObject parent = Instantiate(empty, transform.position, Quaternion.identity);
            
            foreach (var placeToWpawn in toInstantiate)
            {
                Instantiate(hexagonPref,
                    placeToWpawn.position + transform.position,
                    Quaternion.identity,
                    parent.transform);
            }
        }
    }

    private void nextlevel()
    {
        iteration++;
        updateCamera();
    }

    private void updateCamera()
    {
        updatePrefabToSpawn();
        if (iteration == 1)
        {
            FindObjectOfType<Camera>().transform.position = new Vector3(0, 1, -20);
            radius = 15;
        }

        if (iteration == 2)
        {
            FindObjectOfType<Camera>().transform.position = new Vector3(0, 1, -40);
            radius = 30;
        }

        if (iteration == 3)
        {
            FindObjectOfType<Camera>().transform.position = new Vector3(0, 1, -60);
            radius = 45;
        }

        if (iteration == 4)
        {
            FindObjectOfType<Camera>().transform.position = new Vector3(0, 1, -80);
            radius = 60;
        }
    }

    private void updatePrefabToSpawn()
    {
        FindObjectOfType<ObjectCollector>().Collect();
    }
}