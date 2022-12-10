using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTypes : MonoBehaviour,IInteract
{
    ObjectType type1 = ObjectType.Obstacle;
    public void Interact(ObjectType type, Transform _transform, Action<ObjectType, Transform> action)
    {
        switch (type)
        {
            case ObjectType.Player:
                action.Invoke(type1, transform);
                break;
            default:
                break;
        }
    }

}
