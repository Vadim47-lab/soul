using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private EnemyDisplay _enemyDisplay;
    [SerializeField] private TMP_Text _scoreText;

    private int _score;

    private void OnEnable()
    {
        _enemy.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _enemy.ScoreChanged -= OnScoreChanged;
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
        Debug.Log("Вызов метода OnScoreChanged в классе Score");
        _score++;
        ShowScore();
        DefeatedEnemy(_score);
    }

    private void DefeatedEnemy(int score)
    {
        if (score == _enemyDisplay.TransformCountEnemy && SceneManager.sceneCount == 1)
        {
            SceneManager.LoadScene(2);
        }
    }
}