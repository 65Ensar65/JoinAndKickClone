using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MyBaseBehaviour,IPlayer
{
    ObjectType type = ObjectType.Player;

    private bool _IsAttack = true;
    private bool _IsFight;
    private bool _IsBossAttack;

    public float Health = 100;
    public bool IsAttack
    { 
        get
        {
            return _IsAttack;
        }
        set
        {
            if (_IsAttack)
            {
                var BossDistance = GameManager.Instance.Boss.position - transform.position;

                if (!_IsFight)
                {

                    if (BossDistance.magnitude <= GameManager.Instance.BossMaxDistance * GameManager.Instance.BossMaxDistance)
                    {
                        _IsBossAttack = true;
                        transform.parent = null;
                    }

                    if (_IsBossAttack)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, GameManager.Instance.Boss.position,
                                                                                     GameManager.Instance.AttackSpeed);

                        var LookBossRot = new Vector3(GameManager.Instance.Boss.position.x, transform.position.y,
                                                      GameManager.Instance.Boss.position.z) - transform.position;

                        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(LookBossRot, Vector3.up), 10 * Time.deltaTime);
                        transform.PlayAnim((int)AnimState.RUNNING);
                    }
                }

                if (BossDistance.magnitude <= GameManager.Instance.BossMinDistance * GameManager.Instance.BossMinDistance)
                {
                    _IsFight = true;

                    var LookBossRot = new Vector3(GameManager.Instance.Boss.position.x, transform.position.y,
                                                  GameManager.Instance.Boss.position.z) - transform.position;

                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(LookBossRot, Vector3.up), 10 * Time.deltaTime);
                    transform.PlayAnim((int)AnimState.FIGHT);
                    e_rigidbody.velocity = Vector3.zero;
                    e_rigidbody.isKinematic = false;
                    e_rigidbody.useGravity = true;
                    e_collider.isTrigger = false;
                    e_bossAnim.IsHit = true;
                }

                else
                {
                    _IsFight = false;
                }
            }
            
        }
    }

    private void Update()
    {
        IsBoolAttack();
        GetPlayerControl();
    }

    public void GetPlayerControl()
    {
        if (Health <= 0)
        {
            for (int i = 0; i < 1; i++)
            {
                e_objectPool.ActivePoolObject(ObjectTag.PlayerBlood, transform);
                e_objectPool.ActivePoolObject(ObjectTag.PlayerBloodEffect, transform);
            }
            Destroy(gameObject);
        }
    }
    public void IsBoolAttack()
    {
        IsAttack = true;
        Mathf.Clamp(Health, 0, 100);

        if (e_bossController.IsDead)
        {
            transform.PlayAnim((int)AnimState.DANCE);
        }
    }

    private void SelectFuncHit(ObjectType type, Transform otherPlayer)
    {
        switch (type)
        {
            case ObjectType.PrefabPlayer:
                break;
            case ObjectType.Boss:
                Health -= Random.Range(1f, 1.5f);
                break;
            case ObjectType.Obstacle:

                for (int i = 0; i < 1; i++)
                {
                    e_objectPool.ActivePoolObject(ObjectTag.PlayerBlood, transform);
                    e_objectPool.ReturnPoolObject(ObjectTag.PlayerBlood, gameObject);
                }

                Destroy(gameObject);
                break;
            default:
                break;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        other.GetComponent<IInteract>()?.Interact(this.type,transform,SelectFuncHit);
    }

    private void OnTriggerStay(Collider other)
    {
        other.GetComponent<IInteract>()?.Interact(this.type, transform, SelectFuncHit);
    }

    
}
