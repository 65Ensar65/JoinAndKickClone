using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerType : MyBaseBehaviour,IInteract
{
    ObjectType objectType = ObjectType.PrefabPlayer;
    [SerializeField] SkinnedMeshRenderer PlayerRenderer;

    public void Interact(ObjectType type, Transform _transform, Action<ObjectType, Transform> action)
    {
        switch (type)
        {
            case ObjectType.Player:
                transform.parent = GameManager.Instance.PlayersParent;
                gameObject.AddComponent<PlayerAnimRotateController>();
                gameObject.AddComponent<PlayerController>();
                PlayerRenderer.material.color = GameManager.Instance.CountMaterial.color;
                Destroy(GetComponent<PlayerTriggerType>());
                action.Invoke(objectType, _transform);
                break;
            default:
                break;
        }
    }
}
