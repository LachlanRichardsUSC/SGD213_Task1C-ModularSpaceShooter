using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineDirection : EngineBase
{
    /// <summary>
    /// An inheritance of EngineBase, controls the speed and direction of
    /// an object in the scene.
    /// </summary>
    [SerializeField]
    // Initial velocity at which the object starts moving
    private float initialVelocity = 10f;

    [SerializeField]
    // The fixed direction of movement
    private Vector2 fixedDirection = new Vector2(0, 1);

    /// <summary>
    /// Property to get/set the fixed direction of movement.
    /// Ensures that the direction is always a unit vector.
    /// </summary>
    public Vector2 Direction
    {
        get => fixedDirection;
        set => fixedDirection = (value.magnitude == 1) ? value : value.normalized;
    }
    protected override void Start()
    {
        // Ensure base class initialization
        base.Start();
        // Apply initial velocity
        rb.velocity = fixedDirection * initialVelocity;
    }

    void FixedUpdate()
    {


        // Calculate and apply force based on the fixed direction and acceleration
        Vector2 forceToAdd = fixedDirection * Acceleration * Time.deltaTime;
        rb.AddForce(forceToAdd);
    }


}
