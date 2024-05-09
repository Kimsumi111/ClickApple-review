using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class NoteManager : MonoBehaviour
{
    public static NoteManager Instance;

    [SerializeField] private KeyCode[] initKeyCodeArr; // �ʱ� Ű �ڵ� ��Ʈ �Ŵ����� ����
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
        _noteGroupClass.Activate(_keyCode);  // ��Ʈ�׷쿡 Ű �ڵ� ��

        this.noteGroupClassList.Add(_noteGroupClass);
    }
    public void OnInput(KeyCode _keycode)
    {
        int _randID = Random.Range(0, noteGroupClassList.Count);
        NoteGroup _randNoteGroupArr = this.noteGroupClassList[_randID]; // ���, ��纣�� ���� ���� ����

        foreach (NoteGroup _noteGroupClass in this.noteGroupClassList)
        {
            _noteGroupClass.OnSpawnNote(_noteGroupClass == _randNoteGroupArr); // ���, ��纣�� ���� �� ���� ����
            bool _isSelected = _noteGroupClass.GetKeyCode == _keycode;
            _noteGroupClass.OnInput(_isSelected);   // ��ư �ִϸ��̼� ���� �� �� �� ��Ʈ ����
        }
    }
}
