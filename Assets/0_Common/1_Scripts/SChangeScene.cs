using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SChangeScene : MonoBehaviour
{
    public SFade FacdScrp = null;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(FacdScrp.FadeCtrl())
        {
            SceneManager.LoadScene("1_MenuScene");
        }
    }
}
