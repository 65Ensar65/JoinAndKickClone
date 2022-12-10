using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderScripts : MonoBehaviour,IObstacle
{
    void Update()
    {
        GetObstacleController();
    }

    public void GetObstacleController()
    {
        transform.Rotate(new Vector3(0, 0,GameManager.Instance.CylindeSpeed));
    }
}
