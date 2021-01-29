using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // PUBLIC
    public int Speed = 5;
    public float MovementDistance = 1f; // Determines how much to move a player
    public Vector2 PlayerDirection;
    public bool CanMove = true;
    public Vector3 Movement;

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
        // rigidbody2d.AddForce(movement * speed * 10f);
        _RigidBody.MovePosition(transform.position + Movement.normalized * Speed * Time.deltaTime);

    }

    // Handles all checks for player movement
    void Move()
    {
        if (!CanMove)
        {
            Movement = Vector3.zero;
            return;
        }
        Movement = Vector3.zero;
        // wasd or arrow keys. Let the user pick?
        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxisRaw("Vertical");

        if (Movement != Vector3.zero)
        {
            PlayerDirection.x = Movement.x;
            PlayerDirection.y = Movement.y;
        }
        else
        { 
        }

        /*if (Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            MoveUp();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            MoveDown();
        }*/
    }

    // Moves player right
    void MoveRight()
    {
        transform.position = new Vector3(transform.position.x + MovementDistance, transform.position.y, transform.position.z);
    }

    // Moves player left
    void MoveLeft()
    {
        transform.position = new Vector3(transform.position.x - MovementDistance, transform.position.y, transform.position.z);
    }

    // Moves player up
    void MoveUp()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + MovementDistance, transform.position.z);
    }

    // Moves player down
    void MoveDown()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - MovementDistance, transform.position.z);
    }
}
