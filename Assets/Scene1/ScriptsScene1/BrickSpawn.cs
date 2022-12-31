using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BrickSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _pref;
    [SerializeField] private float BrickOriginPositionX;
    [SerializeField] private float BrickOriginPositionY;
    [SerializeField] private float BrickSpaceX;
    [SerializeField] private float BrickSpaceY;
    [SerializeField] private int BrickCountX;
    [SerializeField] private int BrickCountY;
    [SerializeField] private GameObject _brickParent;
    private Block _block;
    [SerializeField] private WinningCondition _win;

    void Start()
    {
        for (int i = 0; i <= BrickCountX; i++)
        {
            for (int j = 0; j <= BrickCountY; j++)
            {
                GameObject game = Instantiate(_pref,new Vector3(BrickOriginPositionX + i * BrickSpaceX, BrickOriginPositionY + j * BrickSpaceY, 0f), Quaternion.identity);
                _win._Blocks.Add(game);
                _block = game.GetComponent<Block>();
                _block.health = Random.Range(1, 2 + _block.NumberOfFortifiers);
                game.transform.SetParent(_brickParent.transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i <= BrickCountX; i++)
        {
            
            for (int j = 0; j <= BrickCountY; j++)
            {
                Gizmos.DrawWireCube(new Vector3(BrickOriginPositionX + i * BrickSpaceX, BrickOriginPositionY + j* BrickSpaceY, 0f),new Vector3(1f,0.2f,0));
            }
            
        }
        
    }
}
