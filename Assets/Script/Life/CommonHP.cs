using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommonHP : MonoBehaviour
{
    public ChatacterData ChatacterData;
    private CommonMove CommonMove;

    [HideInInspector] public float HP;
    private float Damage;
    private float Def;
    [SerializeField] private float HurtAdjust;

    protected Animator Animator;

    public float DisappearTime;

    public Slider Slider;
    public Gradient Gradient;
    public Image Fill;

    void Start()
    {
        HP = ChatacterData.HP;
        Def = ChatacterData.Def;
        HurtAdjust = 1;

        Slider.maxValue = HP;
        Fill.color = Gradient.Evaluate(1f);

        Animator = this.GetComponent<Animator>();
        CommonMove = this.GetComponent <CommonMove>();
    }

    public void Hurt(float AttackerAtk, Vector2 AttackerPos)
    {
        Damage = (AttackerAtk - Def) * HurtAdjust;

        HP -= Damage;

        Slider.value = HP;
        Fill.color = Gradient.Evaluate(Slider.normalizedValue);

        if (Damage > 0)
        {
            Animator.SetTrigger("Hurt");

            if (AttackerPos.x > transform.position.x)
                CommonMove.CallDash(-1, Damage * 1f);
            else if (AttackerPos.x < transform.position.x)
                CommonMove.CallDash(1, Damage * 1f);

        }


        DieCheck();

        Debug.Log(this.name + HP.ToString());
    }

    public IEnumerator HurtAdjustSet(int Value)
    {
        HurtAdjust = Value;

        yield return new WaitForSeconds(ChatacterData.InvincibleLength);

        HurtAdjust = 1;
    }

    public void DieCheck()
    {
        if (HP <= 0)
        {
            Animator.SetBool("Die", true);
            this.gameObject.layer = 0;
            Invoke("Disappear", DisappearTime);
        }
    }

    private void Disappear()
    {
        this.gameObject.SetActive(false);
        Slider.gameObject.SetActive(false);
    }

    public void ResetEnemy(Vector3 GeneratePoint)
    {
        this.gameObject.layer = 7;
    }
}
