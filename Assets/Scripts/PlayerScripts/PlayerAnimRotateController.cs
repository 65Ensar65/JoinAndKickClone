using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimRotateController : MyBaseBehaviour,IPlayerAnimRotate
{
    private void Start()
    {
        transform.parent = GameManager.Instance.PlayersParent;
    }
    void Update()
    {
        JoystickController();
    }

    public void JoystickController()
    {

        transform.parent = GameManager.Instance.PlayersParent;

        if (e_joystick.Horizontal != 0)
        {
            transform.PlayAnim((int)AnimState.RUNNING);

            transform.rotation = Quaternion.Slerp(transform.rotation,
                                 Quaternion.Euler(transform.rotation.x,
                                      Mathf.Clamp(transform.rotation.y + (e_joystick.Horizontal * GameManager.Instance.RotateSpeed * Time.deltaTime),
                                                                     -GameManager.Instance.RotateClamp, GameManager.Instance.RotateClamp),
                                                 transform.rotation.z),GameManager.Instance.RotateSmooth);
                                                  
        }

        else
        {
            transform.PlayAnim((int)AnimState.IDLE);
        }
    }
}

public enum AnimState
{
    IDLE,
    RUNNING,
    DANCE,
    FIGHT
}
