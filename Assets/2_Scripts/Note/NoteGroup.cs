using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteGroup : MonoBehaviour
{
    [SerializeField] private int maxNoteNum = 5;
    [SerializeField] private Note baseNoteClass = null;
    [SerializeField] private float noteIntervalGap = 1.0f;
    [SerializeField] Transform noteSpawnTrf = null;

    List<Note> noteClassList = new List<Note>();

    void Start()
    {
        for (int i = 0; i < this.maxNoteNum; i++)
        {
            Note _noteClassObj = Instantiate(baseNoteClass);
            _noteClassObj.transform.SetParent(this.noteSpawnTrf);
            _noteClassObj.transform.localPosition = Vector2.up * this.noteClassList.Count * this.noteIntervalGap;
            _noteClassObj = _noteClassObj.GetComponent<Note>();

            this.noteClassList.Add(_noteClassObj);
        }
    }

}
