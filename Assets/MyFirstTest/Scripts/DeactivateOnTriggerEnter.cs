﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateOnTriggerEnter : MonoBehaviour
{
    // Test
    void OnTriggerEnter (Collider other)
    {
        gameObject.SetActive(false);
    }
}
