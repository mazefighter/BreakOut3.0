using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private bool _OnOrOff = false;

    public delegate void OnOrOff(bool _switch);
    public event OnOrOff Pause;
    [SerializeField]private GameObject _pause;
    [SerializeField] private Button _button;
    private bool _continue = false;
    void Start()
    {
        _button.onClick.AddListener(Clicked);
    }

    private void Clicked()
    {
        _continue = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_OnOrOff)
            {
                _pause.SetActive(false);
                _OnOrOff = false;
            }
            else
            {
                _pause.SetActive(true);
                _OnOrOff = true;
            }
            Pause?.Invoke(_OnOrOff);
            
        }

        if (_continue)
        {
            _pause.SetActive(false);
            _OnOrOff = false;
            Pause?.Invoke(_OnOrOff);
            _continue = false;
        }
    }
}
