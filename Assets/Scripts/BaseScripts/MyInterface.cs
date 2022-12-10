using System;
using UnityEngine;

public interface IJoystick
{
    void SwipeRotate();
}

public interface IPlayerAnimRotate
{
    void JoystickController();
}

public interface IInteract
{
    void Interact(ObjectType type , Transform _transform , Action<ObjectType,Transform> action);
}

public interface IPlayer
{
    void IsBoolAttack();
    void GetPlayerControl();
}

public interface IBoss
{
    void GetBossController();
}

public interface IObstacle
{
    void GetObstacleController();
}

public enum ObjectType
{
    Player,
    Boss,
    PrefabPlayer,
    BossArea,
    Obstacle
}
