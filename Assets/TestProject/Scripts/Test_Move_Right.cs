using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SurvivalShooter;
using GGL;

[RequireComponent(typeof(PlayerMotor))]
public class Test_Move_Right : Test
{

    public float forwardForce = 100f;
    public float minDistance = 2f;

    private float oldXPos;

    private PlayerMotor motor;
    private Vector3 movement;

	// Use this for initialization
	void Start ()
    {
        motor = GetComponent<PlayerMotor>();

        oldXPos = transform.position.x;
	}

    public override void FixedSimulate()
    {
        motor.Move(new Vector3(forwardForce, 0, 0));
    }

    public override void Check()
    {
        float newXPos = transform.position.x;
        float width = newXPos - oldXPos;

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
