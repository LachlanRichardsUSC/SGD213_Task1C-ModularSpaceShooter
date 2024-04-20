using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineBase : MonoBehaviour
{
    /// <summary>
    /// An extendable Base class that controls the movement of all the objects within the scene.
    /// Can allow for dynamic acceleration through encapsulates
    /// and ensures the value never goes below zero.
    /// </summary>
    [SerializeField]
    private float acceleration = 50f;

    // Encapsulating acceleration to control its modification
    public float Acceleration
    {
        // Ensures acceleration is never negative
        get => acceleration;
        set => acceleration = Mathf.Max(0, value);  
    }

    // Local reference to Rigidbody2D with protected access
    protected Rigidbody2D rb;

    // Initialization method marked virtual for subclass extension
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component missing from GameObject " + gameObject.name);
        }
    }

    /// <summary>
    /// Accelerate takes a direction as a parameter and applies a force in this provided direction
    /// to our Rigidbody based on the acceleration variables and the delta time.
    /// </summary>
    /// <param name="direction">A direction vector, expected to be a unit vector (magnitude of 1).</param>
    public void Accelerate(Vector2 direction)
    {
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D is not initialized.");
            return;
        }
        Vector2 forceToAdd = direction * Acceleration * Time.deltaTime;
        rb.AddForce(forceToAdd);
    }

    /// <summary>
    /// Returns the current speed of the Rigidbody.
    /// </summary>
    public float CurrentSpeed
    {
        get
        {
            if (rb == null)
            {
                Debug.LogError("Rigidbody2D is not initialized.");
                return 0;
            }
            return rb.velocity.magnitude;
        }
    }
}
