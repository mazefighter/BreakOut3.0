using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Block : MonoBehaviour
{
    public int NumberOfFortifiers;
    public int health;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite[] _spriteArr;
    [SerializeField] private float InstaKillAvg;
    private bool change = true;
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (health)
        {
            case 0:
                gameObject.SetActive(false);
                break;
            case 1:
                _spriteRenderer.sprite = _spriteArr[0];
                break;
            case 2:
                _spriteRenderer.sprite = _spriteArr[1];
                break;
            case 3:
                _spriteRenderer.sprite = _spriteArr[2];
                break;
            case 4:
                _spriteRenderer.sprite = _spriteArr[3];
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        float InstaKill = Random.Range(0f, 10f);
        if (InstaKill < InstaKillAvg)
        {
            if (health <= 3)
            {
                health = 0;
                change = false;
            }
            
        }
        if(change)
        {
            health--;
            change = true;
        }
    }
}
