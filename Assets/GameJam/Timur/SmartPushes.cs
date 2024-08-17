using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartPushes : MonoBehaviour
{
    [SerializeField] public float pushForce = 100f;
    private int i = 0;
    private List<SmartFigure> list = new List<SmartFigure>();
    void Start()
    {
       list = new List<SmartFigure>(GetComponentsInChildren<SmartFigure>());
    }


    public void OnPushButton()
    {
        if (i < list.Count)
        {
            list[i].pushFigure(pushForce);
            i++;
        }
    }
}
