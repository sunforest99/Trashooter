using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum E_TIME
{
    E_COUNT = 0,
    E_MAX
}

public enum E_TRESH
{
    E_COKE = 0,
    E_PLASTIC,
    E_REDCAN,
    E_CCAN,
    E_PAPER,
    E_MILK,
    E_MAX
}

public class SGameMng : MonoBehaviour
{
    private static SGameMng _Instance = null;

    public static SGameMng I
    {
        get
        {
            if (_Instance == null)
            {
                Debug.Log("instance is null");
            }
            return _Instance;
        }
    }

    public bool bPause;
    public bool bChange;
    public bool bClearCheck;
    public int nScoreCount;
    public int nTRandom = 0;//쓰레기 렌덤 인덱스값

    public SResultScore SResultScrp = null;
    //Jo
    public SThrow GetThrowCtrl;

    void Awake()
    {
        _Instance = this;
    }

    float[] gTime = new float[(int)E_TIME.E_MAX];

    public bool TimeCtrl(int nindex, float DelTime)
    {
        if (gTime[nindex] + DelTime <= Time.time)
        {
            gTime[nindex] = Time.time;
            return true;
        }
        return false;
    }

    public RaycastHit2D GetHitInfo()
    {
        Vector2 ClickPosVec2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        Ray2D ClickRay = new Ray2D(ClickPosVec2, Vector2.zero);

        RaycastHit2D Hit2D = Physics2D.Raycast(ClickRay.origin, ClickRay.direction);

        if (Hit2D.collider != null)

        {
            //Debug.Log(Hit2D.collider.tag);

            return Hit2D;
        }
        return Hit2D;
    }

    public void CollOffCtrl()
    {
        for (int i = 0; i < GetThrowCtrl.GetTrashCanColls.Length; i++)
        {
            GetThrowCtrl.GetTrashCanColls[i].enabled = false;
        }
        
    }

    public void CollOnCtrl()
    {
        for (int i = 0; i < GetThrowCtrl.GetTrashCanColls.Length; i++)
        {
            GetThrowCtrl.GetTrashCanColls[i].enabled = true;
        }

    }
}

