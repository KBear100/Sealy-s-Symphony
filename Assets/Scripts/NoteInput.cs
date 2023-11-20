using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteInput : MonoBehaviour
{
    [SerializeField] KeyCode inputKey;
    [SerializeField] Player player;

    private bool noteInBox;
    private GameObject note;

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

    private void OnTriggerStay2D(Collider2D collision)
    {
        noteInBox = true;
        note = collision.gameObject;
    }

    void HandleNotePress()
    {
        //Debug.Log("Note pressed!");
        if(noteInBox)
        {
            player.score += 100;
            player.combo++;
            Destroy(note.gameObject);
        }
    }

    void HandleNoteRelease()
    {
        //Debug.Log("Note released!");
    }
}



