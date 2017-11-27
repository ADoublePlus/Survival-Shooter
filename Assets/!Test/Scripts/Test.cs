using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Test : MonoBehaviour
{
    public float checkDelay = 1f;

    private float checkTimer = 0f;

    // Update is called once per frame
    void Update()
    {
        Simulate();

        // Check for the check function
        checkTimer += Time.deltaTime;

        if(checkTimer >= checkDelay)
        {
            Check();
            checkTimer = 0;
        }

        Debug();
    }

    // For GizmosGL to perform debugging
    public virtual void Debug()
    {
        
    }

    // Run once per frame
    public virtual void Simulate()
    {
       
    }

    // Perform checks to see whether a test has succeeded or failed
    public abstract void Check();
    
}
