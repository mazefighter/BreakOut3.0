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
    private void OnEnable()
    {
        _losiingCondition.LifeLost += LosiingConditionOnLifeLost;
        _mesh = GetComponent<TextMeshProUGUI>();
        
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
        }
        else
        {
            _mesh.SetText(""+lives);
            int currentscore =_scoreBoard.points / 2;
            score.SetText(""+currentscore);
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
