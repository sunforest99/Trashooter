using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSoundCtrl : MonoBehaviour {

    public Sprite[] ImgSprite = null;
    SpriteRenderer GetSoundCheckSprRend;
    RaycastHit2D Ray;
	// Use this for initialization
	void Start ()
    {
        GetSoundCheckSprRend = transform.GetComponent<SpriteRenderer>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        ClickSoundBtn();

    }

    void ClickSoundBtn()
    {
        Ray = SGameMng.I.GetHitInfo();
        if(Ray.collider!=null && Ray.collider.name=="Sound_Btn" && Input.GetMouseButtonDown(0))
        {
            if (GetSoundCheckSprRend.sprite.name == "Sound_Btn")
            {
                GetSoundCheckSprRend.sprite = ImgSprite[0];
                SSoundMng.I.MainAudio.enabled = false;
            }
            else
            {
                GetSoundCheckSprRend.sprite = ImgSprite[1];
                SSoundMng.I.MainAudio.enabled = true;
            }

        }
    }
}
