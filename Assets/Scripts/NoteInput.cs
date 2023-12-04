using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteInput : MonoBehaviour
{
    [SerializeField] KeyCode inputKey;
    [SerializeField] Player player;

    private bool noteInBox;
    private GameObject note;
    private Touch touch;

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

        //if(Input.touchCount > 0)
        //{
        //    touch = Input.GetTouch(0);
        //    HandleNotePress();
        //}
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        noteInBox = true;
        note = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        noteInBox = false;
    }

    public void HandleNotePress()
    {
        //Debug.Log("Note pressed!");
        if(noteInBox)
        {
            player.score += 100;
            player.combo++;
            Destroy(note.gameObject);
            noteInBox = false;
        }
    }

    void HandleNoteRelease()
    {
        //Debug.Log("Note released!");
    }
}



