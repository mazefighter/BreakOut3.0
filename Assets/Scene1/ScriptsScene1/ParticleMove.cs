using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMove : MonoBehaviour
{

    private ParticleSystem _particleSystem;
    
    // Start is called before the first frame update
    private void OnEnable()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        Block.MoveParticle += BlockOnMoveParticle;
    }
    
    private void OnDisable()
    {
        Block.MoveParticle -= BlockOnMoveParticle;
    }
    private void BlockOnMoveParticle(Vector3 pos, int health)
    {
        var particleSystemMain = _particleSystem.main;
        transform.position = new Vector3(pos.x, pos.y, transform.position.z);
        switch (health)
        {
            case 1:
                particleSystemMain.startColor = new Color(1,1,1);
                break;
            case 2:
                particleSystemMain.startColor = new Color(0.7f, 0.5f, 0.45f);
                break;
        }
        _particleSystem.Emit(10);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
