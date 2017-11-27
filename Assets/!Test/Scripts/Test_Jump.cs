using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GGL; 

[RequireComponent(typeof(PlayerController))]

public class Test_Jump : Test
{
    [Header("Test Parameters")]
    public float minHeight = 1f;

    private PlayerController player;
    private float originY;
    private float jumpApex;

    void Start()
    {
        player = GetComponent<PlayerController>();

        originY = transform.position.y;
    }

    public override void Simulate()
    {
        // Simulate jmup mechanic on the player
        player.Jump();
    }

    public override void Check()
    {
        // Get the current player's position
        float playerY = player.transform.position.y;
        float height = playerY - originY;

        // Get the highest point that the player jumps to (the apex)
        if(height > jumpApex)
        {
            jumpApex = height;
        }

        // Check if the y went up from original psoition
        if(jumpApex > minHeight)
        {
            IntegrationTest.Pass(gameObject);
        }
    }

    public override void Debug()
    {
        GizmosGL.color = Color.red;
        Vector3 originalPos = new Vector3(0, originY, 0);
        Vector3 playerPos = transform.position;

        GizmosGL.AddLine(originalPos, originalPos + Vector3.up * minHeight);

        GizmosGL.AddLine(originalPos, playerPos, 0.35f, 0.35f);
    }
}
