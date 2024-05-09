using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int score;
    [SerializeField] private int maxScore = 100;

    void Awake()
    {
        Instance = this;    
    }
    private void Start()
    {
        UIManager.Instance.OnScore(this.score, this.maxScore);

        NoteManager.Instance.Activate();
    }

    public void OnScore(bool _isCorrect)
    {
        if(_isCorrect)
        {
            score++;    
        }
        else
        {
            score--;
        }
        UIManager.Instance.OnScore(this.score, this.maxScore);
    }
}
