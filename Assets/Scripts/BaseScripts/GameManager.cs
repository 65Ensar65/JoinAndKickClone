using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class GameManager : MyBaseSingleton<GameManager>
{
    [Title("Player Swipe Values")]
    public float SwipeSpeed;
    public float SwipeClamp;
    public float RotateSpeed;
    public float RotateClamp;
    [Range(0, 1)] public float RotateSmooth;
    public Transform PlayersParent;

    [Title("Mallet Values")]
    public float MalletSpeed;

    [Title("Cylinder Values")]
    public float CylindeSpeed;

    [Title("Count Character Values")]
    public Material CountMaterial;

    [Title("Player Attack Values")]
    public Transform Boss;
    public float BossMaxDistance;
    public float BossMinDistance;
    public float AttackSpeed;
}
