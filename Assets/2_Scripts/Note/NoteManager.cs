using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class NoteManager : MonoBehaviour
{
    public static NoteManager Instance;

    [SerializeField] private NoteGroup baseNoteGroupClass;
    [SerializeField] private float noteGroupWidthInterval = 0.5f;
    [SerializeField]
    private KeyCode[] wholeKeyCodeArr = new KeyCode[]
    {
        KeyCode.A,
        KeyCode.S,
        KeyCode.D,
        KeyCode.W,
        KeyCode.X,
        KeyCode.Y,
        KeyCode.Z,
        KeyCode.Q,
        KeyCode.R,
    };
    [SerializeField] private int initNoteGroupNum = 2;

    [SerializeField] private List<NoteGroup> noteGroupClassList;
    void Awake()
    {
        Instance = this;
        noteGroupClassList = new List<NoteGroup>();
    }

    public void Activate()
    {
        for (int i = 0; i < initNoteGroupNum; ++i)
        {
            KeyCode _keyCode = this.wholeKeyCodeArr[i];
            this.OnSpawnNoteGroup(_keyCode);
        }

    }
    public void OnSpawnNoteGroup()
    {
        int activateNoteGroupNum = this.noteGroupClassList.Count;
        KeyCode keyCode = this.wholeKeyCodeArr[activateNoteGroupNum];
        this.OnSpawnNoteGroup(keyCode);
    }
    public void OnSpawnNoteGroup(KeyCode _keyCode)
    {
        GameObject _noteGroupClassObj = GameObject.Instantiate(baseNoteGroupClass.gameObject);
        _noteGroupClassObj.transform.localPosition = Vector2.right * this.noteGroupClassList.Count * this.noteGroupWidthInterval;
        
        NoteGroup _noteGroupClass = _noteGroupClassObj.GetComponent<NoteGroup>();
        _noteGroupClass.Activate(_keyCode);  // ��Ʈ�׷쿡 Ű �ڵ� ��

        this.noteGroupClassList.Add(_noteGroupClass);
    }
    public void OnInput(KeyCode _keycode)
    {
        int _randID = Random.Range(0, noteGroupClassList.Count);
        NoteGroup _randNoteGroupArr = this.noteGroupClassList[_randID]; // ���, ��纣�� ���� ���� ����

        NoteGroup _correctNoteGroupClass = null;
        foreach (NoteGroup _noteGroupClass in this.noteGroupClassList)
        {
            _noteGroupClass.OnSpawnNote(_noteGroupClass == _randNoteGroupArr); // ���, ��纣�� ���� �� ���� ����
            if (_noteGroupClass.GetKeyCode != _keycode)
                _noteGroupClass.OnInput(false);
            else
                _correctNoteGroupClass = _noteGroupClass;  // ��ư �ִϸ��̼� ���� �� �� �� ��Ʈ ����
        }
        if(_correctNoteGroupClass != null)
            _correctNoteGroupClass.OnInput(true);
    }
}
