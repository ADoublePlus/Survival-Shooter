using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SurvivalShooter;
using GGL;

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

    public override void Debug()
    {
        GizmosGL.color = Color.red;
        Vector3 originalPos = new Vector3(0, minHeight, 0);
        Vector3 playerPos = transform.position;

        GizmosGL.AddLine(originalPos, originalPos + Vector3.up * minHeight);

        GizmosGL.AddLine(originalPos, playerPos, 0.35f, 0.35f);
    }

}
