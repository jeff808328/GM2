using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    [HideInInspector] public float DistanceXray;
    private float DistanceXrayLast;
    [HideInInspector] public int PlayerDirection;

    // 距離值

    [Header("ActionIndex Range")]
    // far，mid，near，ramdon

    public float MidMini;
    private float MidMiniOri;

    public float MidMax;
    private float MidMaxOri;

    public float RamdonValue;
    public float Buffer;

    private Vector3 SelfPos;
    private Vector3 MidMiniPos;
    private Vector3 MidMaxPos;

    [HideInInspector] public int ActionIndex; //0,dash 1,jump 2,walk

    [HideInInspector] public bool Nearing;

    #endregion

    #region CheckAttack

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

    public TMP_Text text;

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

        DrawRays();

        if (text != null)
            text.text = ActionIndex.ToString();
    }

    private void InitSet()
    {
        AttackAble = false;
        AirAttackAble = false;

        MidMaxOri = MidMax;
        MidMiniOri = MidMini;

        RandonDistance();
    }

    private void DrawRays()
    {
        Debug.DrawRay(RayCastSourcePos, RayCastDirection, Color.yellow, 1000f);

        SelfPos = this.transform.position;

        MidMiniPos = new Vector3(SelfPos.x + MidMini * PlayerDirection, 0, 0); // 加上移動方向參數

        MidMaxPos = new Vector3(SelfPos.x + MidMax * PlayerDirection, 0, 0);

        Debug.DrawRay(MidMiniPos, new Vector3(0, 1, 0), Color.red, 1000f);
        Debug.DrawRay(MidMaxPos, new Vector3(0, 1, 0), Color.blue, 1000f);
    }

    private void SearchPlayer()
    {

        var PO = Physics2D.OverlapBox(ViewBoxCenter, ViewBoxSize, 0, Player);

        //Debug.Log(PO.gameObject.name);

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

      //  Debug.Log(RH.collider.name);

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
                ActionIndex = 0; // far = 0
            else if (DistanceXray < MidMini)
                ActionIndex = 2; // near = 2
            else
                ActionIndex = 1; // mid = 1

            PlayerDirection = ((PlayerPos.transform.position.x - this.transform.position.x) < 0) ? -1 : 1;

            DistanceXrayLast = DistanceXray;
        }
    }

    private void UpdateCollision()
    {
        AttackBoxCenter = new Vector2(transform.position.x + BoxWideAdjust * PlayerDirection,
                           transform.position.y + BoxHighAdjust * transform.localScale.y);

        AttackBoxSize = new Vector2(transform.lossyScale.x * BoxWide, transform.lossyScale.y * BoxHeight); // attackable


        ViewBoxCenter = new Vector2(transform.position.x + ViewBoxWideAdjust * PlayerDirection,
                           transform.position.y + ViewBoxHighAdjust);

        ViewBoxSize = new Vector2(ViewBoxWide, ViewBoxHeight); // faceplayer


        AirBoxCenter = new Vector2(transform.position.x + AirBoxWideAdjust * PlayerDirection,
                         transform.position.y + AirBoxHighAdjust * transform.localScale.y);

        AirBoxSize = new Vector2(transform.lossyScale.x * AirBoxWide, transform.lossyScale.y * AirBoxHeight); // airattackable


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

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(AirBoxCenter, AirBoxSize);
    }

    // 記得補上牆壁偵測
}
