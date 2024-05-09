using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteGroup : MonoBehaviour
{
    [SerializeField] private int maxNoteNum = 5;
    [SerializeField] private Note baseNoteClass = null;
    [SerializeField] private float noteIntervalGap = 1.0f;
    [SerializeField] Transform noteSpawnTrf = null;
    [SerializeField] SpriteRenderer btnSrdr = null;
    [SerializeField] Sprite normalBtnSprite = null;
    [SerializeField] Sprite selectedBtnSprite = null;
    [SerializeField] Animation anim = null;
    [SerializeField] private KeyCode keyCode;

    List<Note> noteClassList = new List<Note>();

    public KeyCode GetKeyCode => this.keyCode;

    void Start()
    {
        for (int i = 0; i < this.maxNoteNum; i++)
        {
            OnSpawnNote(true);
        }
    }

    public void OnSpawnNote(bool _isApple)
    {
        Note _noteClassObj = Instantiate(baseNoteClass);
        _noteClassObj.transform.SetParent(this.noteSpawnTrf);
        _noteClassObj.transform.localPosition = Vector2.up * this.noteClassList.Count * this.noteIntervalGap;
        _noteClassObj = _noteClassObj.GetComponent<Note>();
        _noteClassObj.Activate(_isApple);

        this.noteClassList.Add(_noteClassObj);
    }

    public void OnInput(bool _isSelected)
    {
        Note _noteClass = noteClassList[0];
        _noteClass.OnInput(_isSelected);

        this.noteClassList.RemoveAt(0);

        for (int i = 0; i < noteClassList.Count; i++)
            noteClassList[i].transform.localPosition = Vector2.up * i * this.noteIntervalGap;

        if (_isSelected) {
            this.btnSrdr.sprite = this.selectedBtnSprite;
            this.anim.Play();
        }       
    }
    void CallBack()
    {
        this.btnSrdr.sprite = this.normalBtnSprite;
    }
}
