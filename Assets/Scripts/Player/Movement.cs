using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // PUBLIC
    public int speed = 5;
    public float movementDistance = 1f; // Determines how much to move a player
    public Vector2 playerDirection;
    public bool canMove = true;
    public Vector3 movementVector;

    // PRIVATE
    private float _Horizontal;
    private float _Vertical;
    private Rigidbody2D _RigidBody;

    // Start is called before the first frame update
    void Start()
    {
        _RigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    private void FixedUpdate()
    {
        _RigidBody.MovePosition(transform.position + movementVector.normalized * speed * Time.deltaTime);
    }

    // Handles all checks for player movement
    void Move()
    {
        if (!canMove)
        {
            movementVector = Vector3.zero;
            return;
        }

        movementVector = Vector3.zero;
        // wasd or arrow keys
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");

        if (movementVector != Vector3.zero)
        {
            playerDirection.x = movementVector.x;
            playerDirection.y = movementVector.y;
        }
    }
}
