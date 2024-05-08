using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            NoteManager.Instance.OnInput(KeyCode.A);
        if (Input.GetKeyDown(KeyCode.S))
            NoteManager.Instance.OnInput(KeyCode.S);
        if (Input.GetKeyDown(KeyCode.D))
            NoteManager.Instance.OnInput(KeyCode.D);
    }
}
