using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int score;
    [SerializeField] private int maxScore = 100;
    [SerializeField] private float maxTime = 30f;
    
    [SerializeField] private int noteGroupSpawnConditionScore = 10;

    [SerializeField] private GameObject gameClearObj;
    [SerializeField] private GameObject gameOverObj;

    private int noteGroupUnlockCnt = 0;

    void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        UIManager.Instance.OnScore(this.score, this.maxScore);

        NoteManager.Instance.Activate();

        StartCoroutine(OnTimer());

        this.gameClearObj.SetActive(false);
        this.gameOverObj.SetActive(false);
    }
    IEnumerator OnTimer()
    {
        float _currentTime = 0f;
        while (_currentTime < maxTime)
        {
            _currentTime += Time.deltaTime;
            UIManager.Instance.OnTimer(_currentTime, maxTime);

            yield return null;
        }

        // GameOver
        this.gameOverObj.SetActive(true);
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
            if (score >= maxScore)
            {
                //GameClear
                this.gameClearObj.SetActive(true);
            }
        }
        else
        {
            score--;
        }
        UIManager.Instance.OnScore(this.score, this.maxScore);
    }
    public void CallBtn_Restart()
    {

    }
}
