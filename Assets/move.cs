using UnityEngine;

public class move:MonoBehaviour
{
    public float speed = 5f;// movement speed

    private Rigidbody2D rb;// reference to Rigidbody2D component
    private Vector2 movement;// movement input

    void Start()// called before the first frame update
    {
        rb = GetComponent<Rigidbody2D>();// Initialize the Rigidbody2D component
    }

    void Update()// called once per frame
    {
        movement.x = Input.GetAxis("Horizontal");// get horizontal input
        movement.y = Input.GetAxis("Vertical");// get vertical input
        movement.Normalize();// normalize to prevent faster diagonal movement
        Debug.Log("Horizontal: " + movement.x + " Vertical: " + movement.y);// Log the movement input for debugging

    }
    
    void FixedUpdate()// called at fixed intervals for physics updates
    {
        rb.linearVelocity = ( movement * speed);// apply movement to Rigidbody2D
    }

}
