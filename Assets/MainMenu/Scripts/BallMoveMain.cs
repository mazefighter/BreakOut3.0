using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallMoveMain : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Vector3 startpos;
    [SerializeField] float speed;
    [SerializeField] float force;

    void Start()
    {
        startpos = transform.position;
        _rigidbody = GetComponent<Rigidbody2D>();
        StartMovement();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartMovement()
    {
        float rightOrLeft = Random.Range(0f, 2f);
        if (rightOrLeft < 1)
        {
            _rigidbody.velocity = new Vector2(Random.Range(-5f,-4f), -3).normalized * speed;
        }
        else
        {
            _rigidbody.velocity = new Vector2(Random.Range(5f,4f), -3).normalized * speed;
        }
        
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            float distance = Random.Range(-1f, 1f);
            _rigidbody.velocity = new Vector2(distance*force,1).normalized*speed;
        }
    }
}

