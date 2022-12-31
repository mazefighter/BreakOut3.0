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
    [SerializeField] float speed;
    [SerializeField] float force;
    private Vector2 speedcheck;
    [SerializeField] private PauseMenu _pause;
    private Vector2 currentVel;

    private void OnEnable()
    {
        _losiingCondition.LifeLost += LosiingConditionOnLifeLost;
        _pause.Pause += PauseOnPause;
        
    }
    

    private void OnDisable()
    {
        _losiingCondition.LifeLost -= LosiingConditionOnLifeLost;
        _pause.Pause -= PauseOnPause;
    }

    private void PauseOnPause(bool _switch)
    {
        if (_switch)
        {
            currentVel = _rigidbody.velocity;
            _rigidbody.velocity = Vector2.zero;
        }

        if (!_switch)
        {
            _rigidbody.velocity = currentVel;
        }
        
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
        if (_rigidbody.velocity.normalized.x > speedcheck.x||_rigidbody.velocity.normalized.y > speedcheck.y)
        {
            _rigidbody.velocity = _rigidbody.velocity.normalized * speed;
        }
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
            _rigidbody.velocity = new Vector2(Random.Range(-5f,-4f), -3).normalized * speed;
            speedcheck = _rigidbody.velocity;
        }
        else
        {
            _rigidbody.velocity = new Vector2(Random.Range(5f,4f), -3).normalized * speed;
            speedcheck = _rigidbody.velocity;
        }
        
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            float distance = transform.position.x - col.transform.position.x;
            _rigidbody.velocity = new Vector2(distance*force,1).normalized*speed;
        }
    }
}

