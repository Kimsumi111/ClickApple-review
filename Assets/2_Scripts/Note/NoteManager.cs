using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class NoteManager : MonoBehaviour
{
    public static NoteManager Instance;

    [SerializeField] private KeyCode[] initKeyCodeArr; // 초기 키 코드 노트 매니저가 가짐
    [SerializeField] private NoteGroup baseNoteGroupClass;
    [SerializeField] private float noteGroupWidthInterval = 0.5f;

    [SerializeField] private List<NoteGroup> noteGroupClassList;
    void Awake()
    {
        Instance = this;
        noteGroupClassList = new List<NoteGroup>();
    }

    public void Activate()
    {
        foreach (KeyCode _keycode in this.initKeyCodeArr)
            this.OnSpawnNoteGroup(_keycode);
    }
    public void OnSpawnNoteGroup(KeyCode _keyCode)
    {
        GameObject _noteGroupClassObj = GameObject.Instantiate(baseNoteGroupClass.gameObject);
        _noteGroupClassObj.transform.localPosition = Vector2.right * this.noteGroupClassList.Count * this.noteGroupWidthInterval;
        
        NoteGroup _noteGroupClass = _noteGroupClassObj.GetComponent<NoteGroup>();
        _noteGroupClass.Activate(_keyCode);  // 노트그룹에 키 코드 줌

        this.noteGroupClassList.Add(_noteGroupClass);
    }
    public void OnInput(KeyCode _keycode)
    {
        int _randID = Random.Range(0, noteGroupClassList.Count);
        NoteGroup _randNoteGroupArr = this.noteGroupClassList[_randID]; // 사과, 블루베리 랜덤 생성 과정

        foreach (NoteGroup _noteGroupClass in this.noteGroupClassList)
        {
            _noteGroupClass.OnSpawnNote(_noteGroupClass == _randNoteGroupArr); // 사과, 블루베리 구분 및 점수 여부
            bool _isSelected = _noteGroupClass.GetKeyCode == _keycode;
            _noteGroupClass.OnInput(_isSelected);   // 버튼 애니메이션 생성 및 맨 밑 노트 삭제
        }
    }
}
