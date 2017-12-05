using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SurvivalShooter;
using GGL;

[RequireComponent(typeof(PlayerMotor))]
public class Test_Move_Forward : Test
{

    public float forwardForce = 100f;
    public float minDistance = 2f;

    private float oldZPos;

    private PlayerMotor motor;
    private Vector3 movement;

	// Use this for initialization
	void Start ()
    {
        motor = GetComponent<PlayerMotor>();

        oldZPos = transform.position.z;
	}

    public override void FixedSimulate()
    {
        motor.Move(new Vector3(0, 0, forwardForce));
    }

    public override void Check()
    {
        float newZPos = transform.position.z;
        float width = newZPos - oldZPos;

        // Check if width reached minDistance
        if(width >= minDistance)
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
        Vector3 originalPos = new Vector3(minDistance, 0, 0);
        Vector3 playerPos = transform.position;

        GizmosGL.AddLine(originalPos, originalPos + Vector3.right * minDistance);

        GizmosGL.AddLine(originalPos, playerPos, 0.35f, 0.35f);
    }
}
