using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _textAmountEnemy;
    [SerializeField] private int _amountEnemy;

    public int EnemiesCount { get; private set; }

    private void Start()
    {
        EnemiesCount = _amountEnemy;

        ShowAmountEnemy();
    }

    private void ShowAmountEnemy()
    {
        _textAmountEnemy.text = _amountEnemy.ToString();
    }
}