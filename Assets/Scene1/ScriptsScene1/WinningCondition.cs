using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinningCondition : MonoBehaviour
{
    public List<GameObject> _Blocks;
    [SerializeField] GameObject _panel;
    [SerializeField] private GameObject _ball;
    [SerializeField] private TextMeshProUGUI _text;
    private ParticleSystem _panelWin;
    [SerializeField] private TextMeshProUGUI _yourScore;
    [SerializeField] private ScoreBoard _scoreBoard;
    private AudioSource _audio;
    [SerializeField] private AudioSource _background;
    private void OnEnable()
    {
        Block.BlockCollide += BallOnBlockCollide;
        _panelWin = _panel.GetComponent<ParticleSystem>();
        _audio = GetComponent<AudioSource>();
    }
    private void OnDisable()
    {
        Block.BlockCollide -= BallOnBlockCollide;
    }

    private void BallOnBlockCollide()
    {
        int activeBlocks = _Blocks.Count;
        for (int i = 0; i < _Blocks.Count; i++)
        {
            if (!_Blocks[i].gameObject.activeSelf.Equals(true))
            {
                activeBlocks--;
            }
            else
            {
                continue;
            }
        }

        if (activeBlocks == 0)
        {
            _background.Stop();
            _text.SetText("You Win");
            _panel.SetActive(true);
            _ball.SetActive(false);
            _yourScore.SetText("Score: "+_scoreBoard.points);
            _yourScore.gameObject.SetActive(true);
            _panelWin.Play();
            _audio.Play();
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
