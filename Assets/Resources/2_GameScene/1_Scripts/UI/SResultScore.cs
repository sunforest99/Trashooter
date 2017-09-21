using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SResultScore : MonoBehaviour
{
    public Text ScoreText = null;
    public Text HighScore = null;
    public GameObject ResultGame = null;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score :  " + SGameMng.I.nScoreCount.ToString();
        HighScore.text = "High Score :  " + SGameMng.I.nScoreCount.ToString();
        //SGameMng.I.bPause = true;
    }
}
