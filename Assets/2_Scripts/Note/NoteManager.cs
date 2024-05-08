using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public static NoteManager Instance;
    [SerializeField] NoteGroup[] noteGroupClassArr;
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    public void OnInput(KeyCode _keycode)
    {
        int _randID = Random.Range(0, noteGroupClassArr.Length);
        NoteGroup _randNoteGroupArr = this.noteGroupClassArr[_randID];

        foreach (NoteGroup _noteGroupClass in this.noteGroupClassArr)
        {
            _noteGroupClass.OnSpawnNote(_noteGroupClass == _randNoteGroupArr);
            bool _isSelected = _noteGroupClass.GetKeyCode == _keycode;
            _noteGroupClass.OnInput(_isSelected);   // 버튼 애니메이션 생성 및 맨 밑 노트 삭제
        }
    }
}
