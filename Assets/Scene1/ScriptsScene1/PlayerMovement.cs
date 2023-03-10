using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Vector3 Mouse;
    public float speed;
    private Animator _animator;
    [SerializeField] private PauseMenu _pause;
    private bool Pause = false;
    
    private void OnEnable()
    {
        _pause.Pause += PauseOnPause;
        
    }
    

    private void OnDisable()
    {
        _pause.Pause -= PauseOnPause;
    }

    private void PauseOnPause(bool _switch)
    {
        if (_switch)
        {
            Pause = true;
        }

        if (!_switch)
        {
            Pause = false;
        }
        
    }
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Pause)
        {
            Mouse = Input.mousePosition;
            _rigidbody.velocity = new Vector2(Camera.main.ScreenToWorldPoint(Mouse).x - transform.position.x, 0)* speed;
        }

        if (Pause)
        {
            _rigidbody.velocity = Vector2.zero;
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            if (_animator.GetBool("Rainbow"))
            {
                _animator.SetBool("Rainbow", false);
            }
            else
            {
                _animator.SetBool("Rainbow", true);
            }
            
        }
        
    }
}
