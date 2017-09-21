using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SLoadScene : MonoBehaviour
{
    public SFade FacdScrp = null;

    // Update is called once per frame
    void Update()
    {
        if(FacdScrp.FadeCtrl())
        {
            gameObject.SetActive(false);
        }
    }
}
