using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBackGround : MonoBehaviour
{
    public SpriteRenderer BackSpRenderer = null;
    public Sprite[] BgSprite;

    bool bSecondBg;
    bool bThBg;

    // Use this for initialization
    void Start()
    {
        SSoundMng.I.Play("1st_Stage_Bgm", false, true);
    }

    // Update is called once per frame
    void Update()
    {
        if (SGameMng.I.nScoreCount <= 15)
        {
            BackSpRenderer.sprite = BgSprite[0];        // 15점마다 추가
        }
        else if (SGameMng.I.nScoreCount >= 15 && SGameMng.I.nScoreCount <= 30)
        {
            BackSpRenderer.sprite = BgSprite[1];        // 15점마다 추가
        }
        else if (SGameMng.I.nScoreCount >= 30)
        {
            BackSpRenderer.sprite = BgSprite[2];        // 15점마다 추가
        }
    }
}
