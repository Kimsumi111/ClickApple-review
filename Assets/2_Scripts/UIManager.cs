using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private TextMeshProUGUI scoreTmp;
    [SerializeField] private Image scoreImg;

    private void Awake()
    {
        Instance = this;
    }

    public void OnScore(int _currentScore, int _maxScore)
    {
        this.scoreImg.fillAmount = (float)_currentScore / _maxScore;
        this.scoreTmp.text = $"{_currentScore} / {_maxScore}";
    }
}
