using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementMenu : MonoBehaviour
{
    [SerializeField] private GameObject _ball;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_ball.transform.position.x < 5.3 && _ball.transform.position.x > -5.3)
        {
            transform.position = new Vector3(_ball.transform.position.x, transform.position.y,0); 
        }
        
    }
}
