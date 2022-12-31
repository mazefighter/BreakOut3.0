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
    public delegate void PosAndColor(Vector3 pos, int health);
    public static event PosAndColor MoveParticle;

    public delegate void GetHealth(int health);

    public static event GetHealth HealthOnImpact;
    public static event Action BlockCollide;
    
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
                    BlockCollide?.Invoke();
                    break;
                case 1:
                    _spriteRenderer.sprite = _spriteArr[0];
                    break;
                case 2:
                    _spriteRenderer.sprite = _spriteArr[1];
                    break;
            
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        MoveParticle?.Invoke(transform.position,health);
        HealthOnImpact?.Invoke(health);
        health--;
    }
}
