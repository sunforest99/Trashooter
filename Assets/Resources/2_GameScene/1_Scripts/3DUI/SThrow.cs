using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SThrow : MonoBehaviour
{
    public GameObject GarbageGame = null;
    public SpriteRenderer TrashSpriteRenderer = null;
    public GameObject[] TrashGame = null;
    public Sprite[] TrashSprite = null;
    int nRand;
    public STimer TimerScrp = null;
    public float fJumpSize = 100f;
    public float fGravityScale = 3f;
    [SerializeField]
    Rigidbody2D BallRigid;
    Vector2 FirstVec;
    Vector2 EndVec;
    //Kim
    RaycastHit2D Ray;
    [SerializeField]
    bool bCheck;

    //Jo
    public bool bScaleCheck = false;
    Vector3 GetBallVec3;
    Vector2 GetBallVec2;
    public CapsuleCollider2D[] GetTrashCanColls;

    Vector2 ResultVec;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Ray = SGameMng.I.GetHitInfo();

        if (!SGameMng.I.bPause)
        {
            if (TimerScrp.fTimer < 0)
            {
                SGameMng.I.SResultScrp.ScoreText.enabled = true;
                SGameMng.I.SResultScrp.HighScore.enabled = true;

                SGameMng.I.SResultScrp.ResultGame.transform.localPosition = new Vector2(0f, 0f);
            }

            //BallRigid.WakeUp();
            if (Ray.collider != null && Ray.collider.CompareTag("Player") && Input.GetMouseButtonDown(0))
            {
                FirstVec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                bCheck = true;
            }
            if (bCheck)
            {
                EndDrag();
            }
        }
        else
        {
            //BallRigid.Sleep();
        }
        ScaleDownBall();
        Reset();
        CheckPos();
        Debug.Log(ResultVec.magnitude);
    }

    void OnMouseDrag()
    {
        if (!SGameMng.I.bPause)
        {
            EndVec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ResultVec = EndVec - FirstVec;
            if (ResultVec.magnitude > 5f)
            {
                return;
            }
            //터치동안 공이 따라옴
            this.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GetBallVec3 = this.transform.position;
            GetBallVec3.z = 0f;
            this.transform.position = GetBallVec3;
            //터치동안 콜라이더 다끔
            SGameMng.I.CollOffCtrl();
        }
    }

    void EndDrag()
    {
        if (Input.GetMouseButtonUp(0))
        {
            //    SGameMng.I.CollOnCtrl();
            //    Vector2 ResultVec = EndVec - FirstVec;
            BallRigid.gravityScale = fGravityScale;                // 중력 적용값
            BallRigid.AddForce(ResultVec * fJumpSize);       // 점프 값
            bScaleCheck = true;
            TimerScrp.fTimer = 10f;
            bCheck = false;
        }
    }

    void ScaleDownBall()
    {
        if (bScaleCheck && transform.localScale.x >= 0.4f)
        {
            GetBallVec2 = transform.localScale;
            GetBallVec2.x -= 0.03f;
            GetBallVec2.y -= 0.03f;
            transform.localScale = GetBallVec2;
        }
        else
        {
            bScaleCheck = false;
        }
    }

    void Reset()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.localPosition = new Vector2(Random.Range(-2.5f, 2.6f), -3.3f);
            BallRigid.velocity = Vector2.zero;
            BallRigid.gravityScale = 0f;
            transform.localScale = new Vector2(1f, 1f);
            transform.localRotation = Quaternion.identity;
            BallRigid.freezeRotation = true;
            transform.localScale = new Vector2(1f, 1f);
        }
    }

    public void Change()
    {
        nRand = Random.Range((int)E_TRESH.E_COKE, (int)E_TRESH.E_MAX);
        switch (nRand)
        {
            case 0:
                TrashSpriteRenderer.sprite = TrashSprite[nRand];
                break;
            case 1:
                TrashSpriteRenderer.sprite = TrashSprite[nRand];
                break;
            case 2:
                TrashSpriteRenderer.sprite = TrashSprite[nRand];
                break;
            case 3:
                TrashSpriteRenderer.sprite = TrashSprite[nRand];
                break;
            case 4:
                TrashSpriteRenderer.sprite = TrashSprite[nRand];
                break;
            case 5:
                TrashSpriteRenderer.sprite = TrashSprite[nRand];
                break;
        }
        for (int i = 0; i < TrashGame.Length; i++)
        {
            if (i != nRand)
            {
                TrashGame[i].SetActive(false);
            }
            else
            {
                TrashGame[i].transform.localPosition = Vector2.zero;
                TrashGame[i].SetActive(true);
            }
        }
        BallRigid.gravityScale = 0f;
        transform.localRotation = Quaternion.identity;
        transform.localPosition = new Vector2(Random.Range(-2.5f, 2.6f), -3.3f);
        BallRigid.velocity = Vector2.zero;
        transform.localScale = new Vector2(1f, 1f);
        transform.localScale = new Vector2(1f, 1f);
        BallRigid.freezeRotation = true;
    }

    void CheckPos()
    {
        if (transform.localPosition.y > (GarbageGame.transform.localPosition.y + 2f))
        {
            SGameMng.I.CollOnCtrl();
        }
    }
}