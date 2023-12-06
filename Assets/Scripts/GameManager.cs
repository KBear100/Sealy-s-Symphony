using Symphony;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private const string s = "Assets/Audio/Spinning Seal - GifSound.mp3";

    //serialize fields
    [SerializeField] AudioSource title_theme;
    [SerializeField] Button start;

    bool buttonPressed = false;

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
        if (game != null)
        {
            Destroy(gameObject);
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
                if (!title_theme.isPlaying)
                {
                    title_theme.Play();
                }
                //SceneManager.LoadScene("Title");
                start.onClick.AddListener(OnPlayGame);
                break;

            case State.SONG_SELECT:
                buttonPressed = false;
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

    /*FUNCTIONS*/
    public void OnPlayGame() //hit play on title screen
    { 
        title_theme.Stop();
        current = State.SONG_SELECT;
        Debug.Log($"Button Pressed: {current}");
        if(!buttonPressed) SceneManager.LoadSceneAsync("SongSelect", LoadSceneMode.Single);
        buttonPressed = true;
    }

    /*CODE CLEANUP*/
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