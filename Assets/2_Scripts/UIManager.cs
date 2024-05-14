using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private TextMeshProUGUI scoreTmp;
    [SerializeField] private Image scoreImg;
    [SerializeField] private TextMeshProUGUI timerTmp;
    [SerializeField] private Image timerImg;


    private void Awake()
    {
        Instance = this;
    }
    public void OnScore(int _currentScore, int _maxScore)
    {
        this.scoreImg.fillAmount = (float)_currentScore / _maxScore;
        this.scoreTmp.text = $"{_currentScore} / {_maxScore}";
    }
    public void OnTimer(float _currentTime, float _maxTime)
    {
        this.timerImg.fillAmount = (float)_currentTime / _maxTime;
        this.timerTmp.text = $"{_currentTime.ToStringN(1)} / {_maxTime.ToStringN(1)}";
    }
}

