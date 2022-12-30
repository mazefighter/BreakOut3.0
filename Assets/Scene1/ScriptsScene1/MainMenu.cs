using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _button;
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Clicked);
    }

    private void Clicked()
    {
        SceneManager.LoadScene("MainMenu");
    }
    void Update()
    {
        
    }
}
