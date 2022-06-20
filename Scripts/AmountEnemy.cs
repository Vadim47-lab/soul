using TMPro;
using UnityEngine;

public class AmountEnemy : MonoBehaviour
{
    [SerializeField] private TMP_Text _textAmountEnemy;

    public void ShowAmountEnemy(int countEnemy)
    {
        _textAmountEnemy.text = countEnemy.ToString();
    }
}