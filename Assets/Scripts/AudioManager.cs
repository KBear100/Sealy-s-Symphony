using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] float[] notes;
    int nextIndex = 0;
    [SerializeField] float beatsShownInAdvance;

    void Start()
    {
        secPerBeat = 60f / songBpm;
        dspSongTime = (float)AudioSettings.dspTime;
        musicSource.Play();
    }

    void Update()
    {
        songPosition = (float)(AudioSettings.dspTime - dspSongTime);
        songPositionInBeats = songPosition / secPerBeat;

        beats = (int)songPositionInBeats;

        currentBeat = beats % 4;
        if (currentBeat == 0) currentBeat = 4;

        if(nextIndex < notes.Length && notes[nextIndex] == currentBeat)
        {
            Instantiate(noteObject);
            nextIndex++;
        }
        if(nextIndex >= notes.Length) nextIndex = 0;
    }
}