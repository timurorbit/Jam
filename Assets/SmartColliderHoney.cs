using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartColliderHoney : SmartCollider
{
    public float delayCheck = 0.3f;
    public float radius = 10f;
    public LayerMask layer;
    public Material shineMaterial;
    public Material baseMaterial;

    public bool isTriggered;

    public List<SmartColliderHoney> next;

    [SerializeField] private SpriteRenderer _spriteRenderer;
    
    protected void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (!isTriggered)
        {
            StartCoroutine(checkForHoneys());
            isTriggered = true;
        }
    }

    IEnumerator shineAndNextHoney()
    {
        _spriteRenderer.material = shineMaterial;
        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < next.Count; i++)
        {
            StartCoroutine(next[i].shineAndNextHoney());
        }

        _spriteRenderer.material = baseMaterial;
    }

    IEnumerator checkForHoneys()
    {
        yield return new WaitForSeconds(delayCheck);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius, layer);
        
        List<SmartColliderHoney> tempNext = new List<SmartColliderHoney>();

        foreach (var VARIABLE in colliders)
        {
            SmartColliderHoney colliderHoney = VARIABLE.GetComponentInParent<SmartColliderHoney>();
            if (colliderHoney)
            {
                StartCoroutine(shineAndNextHoney());
                tempNext.Add(colliderHoney);
            }
        }

        next = tempNext;
    }
}
