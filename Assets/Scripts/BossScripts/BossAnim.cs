using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnim : MonoBehaviour
{
    [HideInInspector] public bool IsHit = false;

    private void Update()
    {
        GetHit();
        GetIdle();
    }
    public void GetHit()
    {
        if (IsHit)  
        transform.PlayAnim((int)BossState.HIT);
    }

    public void GetIdle()
    {
        if (!IsHit)
        transform.PlayAnim((int)BossState.IDLE);
    }
}
public enum BossState
{
    IDLE,
    HIT
}