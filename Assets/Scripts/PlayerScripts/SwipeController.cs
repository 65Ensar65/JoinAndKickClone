using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MyBaseBehaviour,IJoystick
{
    [SerializeField] float StraightSpeed;
    void Update()
    {
        SwipeRotate();
    }

    public void SwipeRotate()
    {
        if (e_joystick.Horizontal != 0)
        {
            e_rigidbody.velocity = new Vector3(0, 0, StraightSpeed);

            transform.position = new Vector3(Mathf.Clamp(transform.position.x + (GameManager.Instance.SwipeSpeed * e_joystick.Horizontal * Time.deltaTime),
                                                                                -GameManager.Instance.SwipeClamp, GameManager.Instance.SwipeClamp),
                                                         transform.position.y,
                                                         transform.position.z);
        }

        else
        {
            e_rigidbody.velocity = Vector3.zero;
        }
    }
}
