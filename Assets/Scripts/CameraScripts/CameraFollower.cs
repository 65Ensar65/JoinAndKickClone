using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] Vector3 Offset;
    void LateUpdate()
    {
        transform.position = Player.position + Offset;
    }
}
