using Symphony;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private const string s = "Assets/Audio/Spinning Seal - GifSound.mp3";

    //serialize fields
    //AudioClip title_theme = s;
    

    //song list variables
    static int q = 0;
    static int lncount = 0;

    static string[,] songs = new string[26, 6]; //where songs are stored
    static int[] count = new int[26]; //counts the length of each thing
    string filepath = "Assets/ListTest.txt";

    //Initializations
    public static GameManager game { get; private set; }

    enum State
    {
        TITLE,
        SONG_SELECT,
        PLAY,
        WIN,
        LOSE
    }
    State current;

    void Start()
    {
        //get song list and info
        SongInfo.ReadFile(filepath, songs, count, q, lncount);
        //Start Game stuff
        current = State.TITLE;
    }

    // Start is called before the first frame update
    void Awake()
    {
        //Singleton Game Manager
        if (game != null && game != this)
        {
            Destroy(this);
        }
        else
        {
            game = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        switch (current)
        { 
            case State.TITLE:
                SceneManager.LoadScene("Title");
                break;

            case State.SONG_SELECT:
                SceneManager.LoadScene("SongSelect");
                break;

            case State.PLAY:
                SceneManager.LoadScene("SampleScene");
                break;

            case State.WIN:
                break;

            case State.LOSE:
                break;
            
        }
    }

    private void OnApplicationQuit()
    {
        songs = null;
        count = null;
        q = -1;
        lncount = -1;
    }

}

/*
 Credits for code:
 * https://forum.unity.com/threads/how-you-normally-do-about-gamemanager-scenemanager.232648/
 
 */