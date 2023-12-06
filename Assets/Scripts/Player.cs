using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Stats")]
    public int health;
    public int score;
    public int combo;
    [Header("UI")]
    public TMP_Text songTitle_Txt;
    [SerializeField] TMP_Text scoreTxt;
    [SerializeField] TMP_Text comboTxt;
    [SerializeField] Slider healthUI;
    [SerializeField] Slider scoreUI;

    void Start()
    {
        
    }

    void Update()
    {
        scoreTxt.text = "Score: " + score.ToString();
        comboTxt.text = "Combo: " + combo.ToString();
        healthUI.value = health;
        scoreUI.value = score;

        if(health <= 0)
        {
            GameManager.game.SongEnd(score);
            SceneManager.LoadSceneAsync("SongSelect", LoadSceneMode.Single);
        }
    }
}
