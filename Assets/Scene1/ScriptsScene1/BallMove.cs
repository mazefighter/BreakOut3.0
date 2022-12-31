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
    private AudioSource _audio;
    [SerializeField] private ScoreBoard _scoreBoard;
    [SerializeField] private AudioSource _backingtrack;
    private bool speed1 = true;
    private bool speed2 = true;
    private bool speed3 = true;
    private bool speed4 = true;
    private bool switch1 = false;
    private bool switch2 = false;
    private bool switch3 = false;
    private bool switch4 = false;
    private void OnEnable()
    {
        _losiingCondition.LifeLost += LosiingConditionOnLifeLost;
        _pause.Pause += PauseOnPause;
        _audio = GetComponent<AudioSource>();
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

        if (start)
        {
           _rigidbody.velocity = Vector2.zero; 
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

        if (col.gameObject.CompareTag("Block"))
        {
            _audio.Play();
            if (_scoreBoard.points < 1000 && switch1)
            {
                speedcheck = new Vector2(_rigidbody.velocity.x / 1.2f, _rigidbody.velocity.y / 1.2f);
                speed /= 1.2f;
                _backingtrack.pitch -= 0.15f;
                speed1 = true;
                switch1 = false;
            }
            if (_scoreBoard.points>1000 && speed1)
            {
                speedcheck = new Vector2(_rigidbody.velocity.x * 1.2f, _rigidbody.velocity.y * 1.2f);
                speed *= 1.2f;
                _backingtrack.pitch += 0.15f;
                speed1 = false;
                switch1 = true;
            }
            if (_scoreBoard.points>2000 && speed2)
            {
                speedcheck = new Vector2(_rigidbody.velocity.x * 1.2f, _rigidbody.velocity.y * 1.2f);
                speed *= 1.2f;
                _backingtrack.pitch += 0.15f;
                speed2 = false;
                switch2 = true;
            }
            if (_scoreBoard.points < 2000 && switch2)
            {
                speedcheck = new Vector2(_rigidbody.velocity.x / 1.2f, _rigidbody.velocity.y / 1.2f);
                speed /= 1.2f;
                _backingtrack.pitch -= 0.15f;
                speed2 = true;
                switch2 = false;
            }
            if (_scoreBoard.points>3000 && speed3)
            {
                speedcheck = new Vector2(_rigidbody.velocity.x * 1.2f, _rigidbody.velocity.y * 1.2f);
                speed *= 1.2f;
                _backingtrack.pitch += 0.15f;
                speed3 = false;
                switch3 = true;
            }
            if (_scoreBoard.points < 3000 && switch3)
            {
                speedcheck = new Vector2(_rigidbody.velocity.x / 1.2f, _rigidbody.velocity.y / 1.2f);
                speed /= 1.2f;
                _backingtrack.pitch -= 0.15f;
                speed3 = true;
                switch3 = false;
            }
            if (_scoreBoard.points>4000 && speed4)
            {
                speedcheck = new Vector2(_rigidbody.velocity.x * 1.2f, _rigidbody.velocity.y * 1.2f);
                speed *= 1.2f;
                _backingtrack.pitch += 0.15f;
                speed4 = false;
                switch4 = true;
            }
            if (_scoreBoard.points < 4000 && switch4)
            {
                speedcheck = new Vector2(_rigidbody.velocity.x / 1.2f, _rigidbody.velocity.y / 1.2f);
                speed /= 1.2f;
                _backingtrack.pitch -= 0.15f;
                speed4 = true;
                switch4 = false;
            }
            
        }
    }
}

