using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MalletScripts : MonoBehaviour,IObstacle
{
    [SerializeField] float RotatePos;
    void Start()
    {
        GetObstacleController();
    }

    public void GetObstacleController()
    {
        transform.DORotate(new Vector3(0, 0, transform.rotation.z + RotatePos), GameManager.Instance.MalletSpeed).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }
}
