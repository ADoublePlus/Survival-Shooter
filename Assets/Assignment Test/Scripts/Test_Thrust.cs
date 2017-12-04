using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SurvivalShooter;

[RequireComponent(typeof(PlayerMotor))]
public class Test_Thrust : Test
{
    public float upForce = 100f;
    public float minHeight = 2f;

    private float oldYPos;

    private PlayerMotor motor;
    private Vector3 thrusterForce;

    // Use this for initialization
    void Start()
    {
        motor = GetComponent<PlayerMotor>();

        oldYPos = transform.position.y;
    }

    public override void FixedSimulate()
    {
        // Perform thrust here
        motor.ApplyThruster(new Vector3(0, upForce, 0));
    }

    public override void Check()
    {
        float newYPos = transform.position.y;
        float height = newYPos - oldYPos;

        // Check if height reached minHeight
        if (height >= minHeight)
        {
            // Pass the test
            IntegrationTest.Pass(gameObject);
        }
        else
        {
            // Fail the test
            IntegrationTest.Fail(gameObject);
        }
    }

}
