using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MyBaseBehaviour,IInteract,IBoss
{
    ObjectType types = ObjectType.Boss;

    [HideInInspector] public bool IsDead;

    [SerializeField] float BossHealth;
    [SerializeField] GameObject BossBlood;
    [SerializeField] GameObject BossBloodEffect;
    [SerializeField] GameObject Boss;

    private void Update()
    {
        GetBossController();
        Mathf.Clamp(BossHealth, 0, 100);

    }
    public void GetBossController()
    {

        if (BossHealth <= 0)
        {
            BossBlood.SetActive(true);
            BossBloodEffect.SetActive(true);
            Boss.SetActive(false);
            IsDead = true;
        }

        if (GameManager.Instance.PlayersParent.childCount <= 0)
        {
            e_bossAnim.IsHit = false;
        }
    }

    public void Interact(ObjectType type, Transform _transform, Action<ObjectType, Transform> action)
    {
        switch (type)
        {
            case ObjectType.Player:
                BossHealth -= .01f;
                action.Invoke(types, transform);
                break;
            default:
                break;
        }
    }

}


