using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    [SerializeField] private EnemyDisplay _enemyDisplay;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private Enemy[] _enemies;

    private int _score;

    private void OnEnable()
    {
        for (int i = 0; i < _enemies.Length; i++)
        {
            _enemies[i].ScoreChanged += OnScoreChanged;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _enemies.Length; i++)
        {
            _enemies[i].ScoreChanged -= OnScoreChanged;
        }
    }

    private void Start()
    {
        ShowScore();
    }

    private void ShowScore()
    {
        _scoreText.text = _score.ToString();
    }

    private void OnScoreChanged()
    {
        _score++;
        ShowScore();
        DefeatedEnemy();
    }

    private void DefeatedEnemy()
    {
        if (_score == _enemyDisplay.TransformCountEnemy && SceneManager.sceneCount == 1)
        {
            SceneManager.LoadScene(2);
        }
    }
}