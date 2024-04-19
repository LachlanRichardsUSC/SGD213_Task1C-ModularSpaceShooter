using UnityEngine;
using System.Collections;

public class PlayerMovementScript : MonoBehaviour, IEngine
{
    // SerializeField exposes this value to the Editor, but not to other Scripts!
    // It is "pseudo public"
    // HorizontalPlayerAcceleration indicates how fast we accelerate Horizontally
    [SerializeField]
    private float playerSpeed = 5000f;

    private Rigidbody2D rb;

    float IEngine.engineSpeed 
    { 
        get => playerSpeed;
        set  { playerSpeed = value; }
    }

    void IEngine.Move(Vector3 direction)
    {
        Vector2 ForceToAdd = direction * playerSpeed * Time.deltaTime;
        rb.AddForce(ForceToAdd);
    }

    // Use this for initialization
    void Start() {
        // Get OurRigidbodyComponent once at the start of the game and store a reference to it
        // This means that we don't need to call GetComponent more than once! This makes our game faster. (GetComponent is SLOW)
        rb = GetComponent<Rigidbody2D>(); }
    // Update is called once per frame
    void Update() {
        float HorizontalInput = Input.GetAxis("Horizontal");

        if (HorizontalInput != 0.0f) {
            Vector2 ForceToAdd=Vector2.right*HorizontalInput*playerSpeed*Time.deltaTime;
            rb.AddForce(ForceToAdd);
            //print(HorizontalInput);
        } 
    } 
}
