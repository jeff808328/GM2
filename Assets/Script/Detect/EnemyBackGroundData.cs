using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBackGroundData : MonoBehaviour
{
    #region PlayerDetect



    #region Pos

    [Header("ViewBox")]

    private Vector2 ViewBoxCenter;

    [SerializeField] private float ViewBoxWideAdjust;

    [SerializeField] private float ViewBoxHighAdjust;

    #endregion

    #region Size

    private Vector2 ViewBoxSize;

    [SerializeField] private float ViewBoxWide;

    [SerializeField] private float ViewBoxHeight;

    #endregion

    public LayerMask Player;

    #region RayCast

    public bool FacePlayer;

    [Header("GroundDetect")]

    public float RayCastYrayAdjust;

    private Vector2 RayCastSourcePos;

    private Vector2 RayCastDirection;

    public bool PlayerGroundTouching;

    #endregion

    #endregion

    #region CalDistance

    [Header("DistanceCal")]

    [HideInInspector] public Transform PlayerPos;
    public float DistanceXray;
    private float DistanceXrayLast;
    public int PlayerDirection;

    // ¶ZÂ÷­È

    // far¡Amid¡Anear¡Aramdon

    public float MidMini;
    private float MidMiniOri;

    public float MidMax;
    private float MidMaxOri;

    public float RamdonValue;
    public float Buffer;

    public int ActionIndex; //0,dash 1,jump 2,walk

    [HideInInspector] public bool Nearing;

    #endregion

    #region CheckAttack

    [Header("AttackBox")]

    protected Vector2 AttackBoxCenter;

    [SerializeField]
    private float BoxWideAdjust;

    [SerializeField]
    private float BoxHighAdjust;

    protected Vector2 AttackBoxSize;

    [SerializeField]
    private float BoxWide;

    [SerializeField]
    private float BoxHeight;

    public bool AttackAble;



    [Header("AirAttackBox")]

    protected Vector2 AirBoxCenter;

    [SerializeField]
    private float AirBoxWideAdjust;

    [SerializeField]
    private float AirBoxHighAdjust;

    protected Vector2 AirBoxSize;

    [SerializeField]
    private float AirBoxWide;

    [SerializeField]
    private float AirBoxHeight;

    public bool AirAttackAble;

    #endregion

    public bool FlipRayDirection;

    void Start()
    {
        InitSet();
    }

    void Update()
    {
        UpdateCollision();
        UpdateRayCast();

        SearchPlayer();

        if (FacePlayer)
            GroundDetect();

        CalDistance();

        Debug.DrawRay(RayCastSourcePos, RayCastDirection, Color.yellow, 1000f);
    }

    private void InitSet()
    {
        AttackAble = false;
        AirAttackAble = false;

        MidMaxOri = MidMax;
        MidMiniOri = MidMini;

        RandonDistance();
    }

    private void SearchPlayer()
    {

        var PO = Physics2D.OverlapBox(ViewBoxCenter, ViewBoxSize, 0, Player);

        //  Debug.Log(PO.gameObject.name);

        if (PO == null)
        {
            FacePlayer = false;

            PlayerPos = null;

            //       Debug.Log("lose player");
        }
        else
        {
            FacePlayer = true;

            PlayerPos = PO.gameObject.transform;

            //        Debug.Log("find Player");
        }

    }

    private void GroundDetect()
    {
        RaycastHit2D RH = Physics2D.Raycast(RayCastSourcePos, RayCastDirection, Mathf.Infinity);

        Debug.Log(RH.collider.name);

        if (RH.collider.tag != "Player")
        {
            PlayerGroundTouching = false;
        }
        else if (RH.collider.tag == "Player")
        {
            PlayerGroundTouching = true;
        }
    }

    private void CalDistance()
    {
        if (FacePlayer)
        {
            DistanceXray = Mathf.Abs(PlayerPos.transform.position.x - this.transform.position.x);

            Nearing = (DistanceXray >= DistanceXrayLast) ? false : true;

            if (DistanceXray > MidMax)
                ActionIndex = 0;
            else if (DistanceXray < MidMini)
                ActionIndex = 2;
            else
                ActionIndex = 1;

            PlayerDirection = ((PlayerPos.transform.position.x - this.transform.position.x) < 0) ? -1 : 1;

            DistanceXrayLast = DistanceXray;
        }
    }

    private void UpdateCollision()
    {
        AttackBoxCenter = new Vector2(transform.position.x + BoxWideAdjust * PlayerDirection,
                           transform.position.y + BoxHighAdjust * transform.localScale.y);

        AttackBoxSize = new Vector2(transform.lossyScale.x * BoxWide, transform.lossyScale.y * BoxHeight);


        ViewBoxCenter = new Vector2(transform.position.x + ViewBoxWideAdjust * PlayerDirection,
                           transform.position.y + ViewBoxHighAdjust);

        ViewBoxSize = new Vector2(ViewBoxWide, ViewBoxHeight);


        AttackAble = Physics2D.OverlapBox(AttackBoxCenter, AttackBoxSize, 0, Player);
    }

    private void UpdateRayCast()
    {
        RayCastSourcePos = new Vector2(transform.position.x + RayCastDirection.x, transform.position.y + RayCastYrayAdjust);

        if (FlipRayDirection)
            RayCastDirection = new Vector2(-transform.lossyScale.x, 0);
        else
            RayCastDirection = new Vector2(transform.lossyScale.x, 0);
    }

    public void RandonDistance()
    {
        MidMax = MidMax + Random.Range(-RamdonValue - 1, RamdonValue + 1);
        MidMini = MidMini + Random.Range(-RamdonValue - 1, RamdonValue + 1);

        if (MidMax - MidMini < Buffer)
        {
            MidMax = MidMaxOri;
            MidMini = MidMiniOri;

            RandonDistance();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(AttackBoxCenter, AttackBoxSize);

        Gizmos.color = Color.gray;
        Gizmos.DrawWireCube(ViewBoxCenter, ViewBoxSize);
    }

    // °O±o¸É¤WÀð¾À°»´ú
}
