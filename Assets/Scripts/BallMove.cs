using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallMove : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Vector3 startpos;
    [SerializeField] private LosingCondition _losiingCondition;
    private bool start = false;

    private void OnEnable()
    {
        _losiingCondition.LifeLost += LosiingConditionOnLifeLost;
    }

    private void OnDisable()
    {
        _losiingCondition.LifeLost -= LosiingConditionOnLifeLost;
    }

    private void LosiingConditionOnLifeLost()
    {
        transform.position = startpos;
        _rigidbody.velocity = Vector2.zero;
        start = true;
    }

    void Start()
    {
        startpos = transform.position;
        _rigidbody = GetComponent<Rigidbody2D>();
        StartMovement();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space)&& start)
        {
            start = false;
            StartMovement();
        }
    }

    private void StartMovement()
    {
        float rightOrLeft = Random.Range(0f, 2f);
        if (rightOrLeft < 1)
        {
            _rigidbody.velocity = new Vector2(Random.Range(-5f,-4f), -3);
        }
        else
        {
            _rigidbody.velocity = new Vector2(Random.Range(5f,4f), -3);
        }
        
        
    }
}
