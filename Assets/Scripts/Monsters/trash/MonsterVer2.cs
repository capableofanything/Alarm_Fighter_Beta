using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterVer2 : MonoBehaviour
{
    //idle º¸·ù (1.25)
    Define.State nextBehavior = Define.State.MOVE;                  //´ÙÀ½ »óÅÂ
    //to do : MonsterMove or MoveDirection
    Define.PlayerMove nextDirection = Define.PlayerMove.Right;      //´ÙÀ½ ¿òÁ÷ÀÓ ¹æÇâ
    MonsterPattern attackPattern = new LinePattern();               //¸ó½ºÅÍÀÇ °ø°Ý ÆÐÅÏ
    int maxHp = 1;
    int currentHp;
    
    private void Start()
    {
        currentHp = maxHp;

        
        Managers.Timing.BehaveAction -= BitBehave;      //¸ó½ºÅÍÀÇ ºñÆ® ¸¶´Ù ½ÇÇàÇÒ BitBehave ±¸µ¶
        Managers.Timing.BehaveAction += BitBehave;
    }

    protected void BitBehave()
    {
        Animator anim = GetComponent<Animator>();
        switch(nextBehavior)
        {
            // idle º¸·ù
            /*
            case Define.State.IDLE:
                anim.Play("Idle");
                updateIdle();
                break;*/
            case Define.State.ATTACKREADY:
                anim.Play("AttackReady");
                updateAtttackReady();       //AtttackReady ´Ü°è¿¡ ¸Â´Â º¯È­°¡ ³ªÅ¸³ªµµ·Ï ÇÔ
                break;
            case Define.State.ATTACK:
                anim.Play("Attack");
                updateAttack();
                break;
            case Define.State.MOVE:
                anim.Play("Move");
                updateMove();
                break;

        }
    }

    void ChaseCheck()       //¸¸¾à ÇöÀç »óÅÂ°¡ ¿òÁ÷¿©¾ß ÇÏ´Â Define.State.MOVE ¶ó¸é ¿òÁ÷ÀÏ ·£´ý ¹æÇâ ¹ÝÈ¯
    {
        //to do : left or right or Stop Check
        int rand = Random.Range(0, 2);
        switch(rand)
        {
            case 0:
                nextDirection = Define.PlayerMove.Right;
                break;
            case 1:
                nextDirection = Define.PlayerMove.Left;
                break;
            /*case 2:
                nextDirection = Define.PlayerMove.Stop;
                break;*/
        }    
    }


    void updateIdle()
    {
        nextBehavior = Define.State.MOVE;
    }
    void updateMove()
    {
        ChaseCheck();               //¿òÁ÷ÀÏ ·£´ý ¹æÇâ °áÁ¤
        nextBehavior = Define.State.ATTACKREADY;
    }
    void updateAtttackReady()
    {
        AttackReady();              //°ø°ÝÇÒ ¿µ¿ª »¡°­È­
        nextBehavior = Define.State.ATTACK;
    }
    void updateAttack()
    {
        Attack();                   //Damage¿µ¿ª collider È°¼ºÈ­ + Åõ¸íÈ­
        nextBehavior = Define.State.MOVE;
        //nextBehavior = Define.State.IDLE;
        //idle º¸·ù(1.25)
    }
    protected void Attack()
    {
        //int[] pattern = attackPattern.calculateIndex(currentInd);       //¸ó½ºÅÍ°¡ °ø°ÝÇÒ gridÀÇ ÀÎµ¦½º¸¦ pattern¿¡ ¹ÝÈ¯
        //Managers.Field.Attack(pattern);                                 //Damage¿µ¿ª collider È°¼ºÈ­ + Åõ¸íÈ­
    }
    void AttackReady()
    {
        //int[] pattern = attackPattern.calculateIndex(currentInd);       //¸ó½ºÅÍ°¡ °ø°ÝÇÒ gridÀÇ ÀÎµ¦½º¸¦ pattern¿¡ ¹ÝÈ¯
        //Managers.Field.WarningAttack(pattern);                          //ÇØ´ç ¿µ¿ª »¡°­È­
    }


    private void OnTriggerEnter2D(Collider2D collision)                 //PlayerÀÇ °ø°ÝÀ¸·Î ÀÎÇØ¼­ ¸ó½ºÅÍ°¡ È°¼ºÈ­µÈ grid¿¡ ´êÀ» °æ¿ì
    {
        currentHp -= 1;                                                 //¸ó½ºÅÍ´Â ÇÑ¹æ ¸ÂÀ¸¸é µÚÁü
        GetComponent<Animator>().Play("Hit");

        Debug.Log("Monster Hit");
        if (currentHp <= 0)
            Die();
    }
    
    void Die()
    {
        Debug.Log("MonsterDIe!");
        Managers.Game.MinusMonsterNum();
        Managers.Timing.BehaveAction -= BitBehave;                           //ÇöÀç monsterIndex ¹øÂ° ¸ó½ºÅÍÀÇ ºñÆ® ¸¶´Ù ½ÇÇàÇÒ BitBehave ±¸µ¶ ÇØÁ¦
        GameScene gamescene = (GameScene)Managers.Scene.CurrentScene;        //GameScene(½ºÅ©¸³Æ®) ¹ÝÈ¯
        gamescene.NextMonsterIndex();                                        //´ÙÀ½ ¸ó½ºÅÍ »ý¼º
        Destroy(gameObject);
        Managers.Sound.Play("Die", Define.Sound.Effect, 2.0f);

    }
}
