using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBaseBehaviour : MonoBehaviour
{
    [HideInInspector] public Rigidbody e_rigidbody;
    [HideInInspector] public CapsuleCollider e_collider;
    [HideInInspector] public Animator e_animator;
    [HideInInspector] public Joystick e_joystick;
    [HideInInspector] public ObjectPool e_objectPool;
    [HideInInspector] public BossController e_bossController;
    [HideInInspector] public BossAnim e_bossAnim;
    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        e_rigidbody = (GetComponent<Rigidbody>()) ? GetComponent<Rigidbody>() : null;
        e_collider = (GetComponent<CapsuleCollider>()) ? GetComponent<CapsuleCollider>() : null;
        e_animator = (GetComponent<Animator>()) ? GetComponent<Animator>() : null;
        e_joystick = (FindObjectOfType<Joystick>()) ? FindObjectOfType<Joystick>() : null;
        e_objectPool = (FindObjectOfType<ObjectPool>()) ? FindObjectOfType<ObjectPool>() : null;
        e_bossController = (FindObjectOfType<BossController>()) ? FindObjectOfType<BossController>() : null;
        e_bossAnim = (FindObjectOfType<BossAnim>()) ? FindObjectOfType<BossAnim>() : null;
    }
}
