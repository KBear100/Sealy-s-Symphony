using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteInput : MonoBehaviour
{
    public KeyCode inputKey;

    void Update()
    {
        if (Input.GetKeyDown(inputKey))
        {
            HandleNotePress();
        }
        else if (Input.GetKeyUp(inputKey))
        {
            HandleNoteRelease();
        }
    }

    void HandleNotePress()
    {
        Debug.Log("Note pressed!");
    }

    void HandleNoteRelease()
    {
        Debug.Log("Note released!");

    }
}



