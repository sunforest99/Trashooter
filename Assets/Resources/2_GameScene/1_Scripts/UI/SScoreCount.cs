using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SScoreCount : MonoBehaviour
{
    public SThrow ThrowScrp = null;
    public Text ScoreText = null;
    // Use this for initialization
    void Start()
    {
        SGameMng.I.nScoreCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = SGameMng.I.nScoreCount.ToString();
        if(SGameMng.I.bClearCheck)
        {
            //gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Clear"))
        {
            ThrowScrp.Change();
            SGameMng.I.GetThrowCtrl.bScaleCheck = false;
            SGameMng.I.GetThrowCtrl.transform.localScale = new Vector3(1f, 1f, 1f);
            SGameMng.I.nScoreCount++;
            SGameMng.I.bClearCheck = true;
        }
        if (col.gameObject.CompareTag("Over"))
        {
            SGameMng.I.SResultScrp.ScoreText.enabled = true;
            SGameMng.I.SResultScrp.HighScore.enabled = true;
            SGameMng.I.bPause = true;

            SGameMng.I.SResultScrp.ResultGame.transform.localPosition = new Vector2(0f, 0f);
        }
    }
}
