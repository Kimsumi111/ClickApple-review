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
        if (_keycode == KeyCode.A)
            noteGroupClassArr[0].OnInput(true);
        else if (_keycode == KeyCode.S)
            noteGroupClassArr[1].OnInput(false);
    }
}
