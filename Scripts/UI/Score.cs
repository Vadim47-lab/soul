using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    [SerializeField] private EnemyDisplay _enemyDisplay;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private Health _health;

    private int _score;

    private void OnEnable()
    {
        _health.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _health.ScoreChanged -= OnScoreChanged;
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
        DefeatEnemy();
    }

    private void DefeatEnemy()
    {
        if (_score == _enemyDisplay.EnemiesCount)
        {
            TransitionScene();
        }
    }

    private void TransitionScene()
    {
        if (SceneManager.sceneCount == 1)
        {
            SceneManager.LoadScene(2);
        }
    }
}