using UnityEngine;
using System.Collections;

public class EnemyMoveForward : MonoBehaviour {

    private float acceleration = 75f;

    private float initialVelocity = 2f;

    private Rigidbody2D ourRigidbody;

    // Use this for initialization
    void Start()
    {
        ourRigidbody = GetComponent<Rigidbody2D>();

        ourRigidbody.velocity = Vector2.down * initialVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 ForceToAdd = Vector2.down * acceleration * Time.deltaTime;

        ourRigidbody.AddForce(ForceToAdd);
    }
}
