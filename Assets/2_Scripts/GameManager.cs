using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int score;
    [SerializeField] private int maxScore = 100;
    [SerializeField] private int noteGroupSpawnConditionScore = 10;
    private int noteGroupUnlockCnt = 0;

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
            noteGroupUnlockCnt++;
            if (noteGroupSpawnConditionScore <= noteGroupUnlockCnt)
            {
                NoteManager.Instance.OnSpawnNoteGroup();
                noteGroupUnlockCnt = 0;
            }

        }
        else
        {
            score--;
        }
        UIManager.Instance.OnScore(this.score, this.maxScore);
    }
}
