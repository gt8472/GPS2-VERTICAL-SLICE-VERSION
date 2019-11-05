using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Virtual_State_Input rightStick;


    void Update()
    {
        RotatePlayer();
    }

    private void RotatePlayer()
    {
        // Get the facing angle and convert it from rad to deg
        float rotAngle = Mathf.Atan2(rightStick.Direction.x, rightStick.Direction.y) * Mathf.Rad2Deg;

        this.transform.rotation = Quaternion.Euler(0, rotAngle, 0);
    }
}
