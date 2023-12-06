using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SongSelect : MonoBehaviour
{
    [Header("Current")]
    [SerializeField] TMP_Text currentSongName;
    [SerializeField] TMP_Text currentSongArtist;
    [SerializeField] TMP_Text currentSongBPM;
    [SerializeField] Image currentSongImage;
    [Header("Front of Wheel")]
    [SerializeField] TMP_Text frontSongName;
    [SerializeField] TMP_Text frontSongArtist;
    [SerializeField] Image frontSongImage;
    [Header("Top of Wheel")]
    [SerializeField] TMP_Text topSongName;
    [SerializeField] TMP_Text topSongArtist;
    [SerializeField] Image topSongImage;
    [Header("Bottom of Wheel")]
    [SerializeField] TMP_Text bottomSongName;
    [SerializeField] TMP_Text bottomSongArtist;
    [SerializeField] Image bottomSongImage;
    [Header("Song Info")]
    [SerializeField] string[] songNames;
    [SerializeField] string[] songArtists;
    [SerializeField] string[] songBPM;
    [SerializeField] Sprite[] songImages;

    private int songIndex = 0;

    void Start()
    {
        currentSongName.text = songNames[0];
        currentSongArtist.text = songArtists[0];
        currentSongBPM.text = songBPM[0];
        currentSongImage.sprite = songImages[0];

        frontSongName.text = songNames[0];
        frontSongArtist.text = songArtists[0];
        frontSongImage.sprite = songImages[0];
    }

    void Update()
    {
        currentSongName.text = songNames[songIndex];
        currentSongArtist.text = songArtists[songIndex];
        currentSongBPM.text = songBPM[songIndex];
        currentSongImage.sprite = songImages[songIndex];

        frontSongName.text = songNames[songIndex];
        frontSongArtist.text = songArtists[songIndex];
        frontSongImage.sprite = songImages[songIndex];

        if(songIndex == 25)
        {
            bottomSongName.text = songNames[0];
            bottomSongArtist.text = songArtists[0];
            bottomSongImage.sprite = songImages[0];
        }
        else
        {
            bottomSongName.text = songNames[songIndex + 1];
            bottomSongArtist.text = songArtists[songIndex + 1];
            bottomSongImage.sprite = songImages[songIndex + 1];
        }

        if(songIndex == 0)
        {
            topSongName.text = songNames[25];
            topSongArtist.text = songArtists[25];
            topSongImage.sprite = songImages[25];
        }
        else
        {
            topSongName.text = songNames[songIndex - 1];
            topSongArtist.text = songArtists[songIndex - 1];
            topSongImage.sprite = songImages[songIndex - 1];
        }
    }

    public void ToTitle()
    {
        SceneManager.LoadSceneAsync("Title", LoadSceneMode.Single);
    }

    public void Play()
    {
        SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Single);
    }

    public void IncreaseSongIndex()
    {
        if (songIndex == 25) songIndex = 0;
        else songIndex++;
    }

    public void DecreaseSongIndex()
    {
        if (songIndex == 0) songIndex = 25;
        else songIndex--;
    }
}
