using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Music")]
    public float songBpm;
    public float secPerBeat;
    public float songPosition;
    public float songPositionInBeats;
    public int beats;
    public int currentBeat;
    public float dspSongTime;
    public AudioSource musicSource;
    [Header("Note")]
    [SerializeField] GameObject noteObject;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] float[] notes;
    int nextIndex = 0;
    [Header("Player")]
    [SerializeField] Player player;

    bool paused;
    List<Note> currentNotes = new List<Note>();

    void Start()
    {
        secPerBeat = 60f / songBpm;
        dspSongTime = (float)AudioSettings.dspTime;
        musicSource.Play();
        player.songTitle_Txt.text = musicSource.clip.name;
        paused = false;
    }

    void Update()
    {
        if(!paused)
        {
            songPosition = (float)(AudioSettings.dspTime - dspSongTime);
            songPositionInBeats = songPosition / secPerBeat;

            beats = (int)songPositionInBeats;

            currentBeat = beats % 4;
            if (currentBeat == 0) currentBeat = 4;

            if(nextIndex < notes.Length && notes[nextIndex] == currentBeat)
            {
                int rand = Random.Range(0, 4);
                GameObject note = Instantiate(noteObject, spawnPoints[rand].position, spawnPoints[rand].rotation);
                note.GetComponent<Note>().beatOfThisNote = currentBeat;
                note.GetComponent<Note>().player = player;
                currentNotes.Add(note.GetComponent<Note>());
                nextIndex++;
            }
            if(nextIndex >= notes.Length) nextIndex = 0;
        }
    }

    public void Pause()
    {
        if(!paused)
        {
            musicSource.Pause();
            paused = true;
            foreach (var note in currentNotes) note.paused = true;
        }
        else
        {
            musicSource.Play();
            paused = false;
            foreach (var note in currentNotes) note.paused = false;
        }
    }
}
