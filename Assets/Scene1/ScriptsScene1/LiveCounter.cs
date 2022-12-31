using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LiveCounter : MonoBehaviour
{
    [SerializeField] private LosingCondition _losiingCondition;
    private TextMeshProUGUI _mesh;
    private int lives = 3;
    [SerializeField] GameObject _panel;
    [SerializeField] private GameObject _ball;
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private ScoreBoard _scoreBoard;
    private AudioSource _audio;
    [SerializeField] private AudioSource _background;
    private void OnEnable()
    {
        _losiingCondition.LifeLost += LosiingConditionOnLifeLost;
        _mesh = GetComponent<TextMeshProUGUI>();
        _audio = GetComponent<AudioSource>();

    }

    private void OnDisable()
    {
        _losiingCondition.LifeLost -= LosiingConditionOnLifeLost;
    }

    private void LosiingConditionOnLifeLost()
    {
        lives--;
        if (lives < 0)
        {
           _panel.SetActive(true); 
           _ball.SetActive(false);
           _background.Stop();
           _audio.Play();
        }
        else
        {
            _mesh.SetText(""+lives);
            _scoreBoard.points /=  2;
            score.SetText(""+_scoreBoard.points);
        }
        
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
