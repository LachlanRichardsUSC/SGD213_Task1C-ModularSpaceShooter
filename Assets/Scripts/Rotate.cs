using UnityEngine;
using System.Collections;

/// <summary>
/// Simply spins an object with a random angular velocity.
/// </summary>
public class Rotate : MonoBehaviour
{
    [SerializeField]
    private float maximumSpinSpeed = 200;

    void Start()
    {
        GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-maximumSpinSpeed, maximumSpinSpeed);
    }
}
