using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    [SerializeField] private Button _button;
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Clicked);
    }

    private void Clicked()
    {
        Application.Quit();
    }
    void Update()
    {
        
    }
}
