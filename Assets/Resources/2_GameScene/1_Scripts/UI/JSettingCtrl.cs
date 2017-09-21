using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSettingCtrl : MonoBehaviour {

    //public CircleCollider2D GetPlayerColl;
    public Animation GetOptionAni;
    public BoxCollider2D GetCloseBtnColl;
    public bool bOptionCheck = true;
    public void ButtonClick()
    {
        if (bOptionCheck)
        {
            bOptionCheck = false;
            GetCloseBtnColl.enabled = true;
            SGameMng.I.CollOffCtrl();
            //GetPlayerColl.enabled = false;
            GetOptionAni.Play("JOpenOptionAni");
            SGameMng.I.bPause = true;
        }
    }
}
