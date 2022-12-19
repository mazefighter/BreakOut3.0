using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosingCondition : MonoBehaviour
{
    public event Action LifeLost;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        LifeLost?.Invoke();
    }
}
