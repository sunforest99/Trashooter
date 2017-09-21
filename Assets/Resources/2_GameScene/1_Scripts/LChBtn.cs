using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LChBtn : MonoBehaviour
{
    public SThrow ThrowScrp = null;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClick()
    {
        ThrowScrp.Change();
        SGameMng.I.bChange = true;
    }
}
