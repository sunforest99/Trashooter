using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JOffSettingCtrl : MonoBehaviour
{
    //public CircleCollider2D GetPlayerColl;
    public Animation GetOptionAni;
    public BoxCollider2D GetCloseBtnColl;
    public JSettingCtrl GetSettingCtrl;
    RaycastHit2D Ray;

    void Update()
    {
        Ray = SGameMng.I.GetHitInfo();

        if (Ray.collider != null)
        {
            ClickCloseBtn();
        }
    }

    void ClickCloseBtn()
    {
        if (Ray.collider.CompareTag("Exit") && Input.GetMouseButtonDown(0))
        {
            GetSettingCtrl.bOptionCheck = true;
            GetCloseBtnColl.enabled = false;
            GetOptionAni.Play("JCloseOptionAni");
            SGameMng.I.CollOnCtrl();
            // GetPlayerColl.enabled = true;
            SGameMng.I.bPause = false;

            if (SGameMng.I.SResultScrp.ScoreText.enabled)
            {
                SGameMng.I.SResultScrp.ScoreText.enabled = false;
                SGameMng.I.SResultScrp.HighScore.enabled = false;
            }
        }

        if (Ray.collider.CompareTag("RExit") && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("1_MenuScene");
        }

        if (Ray.collider.CompareTag("Again") && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("2_GameScene");
        }
    }


}
