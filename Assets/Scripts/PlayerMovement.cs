using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D _rb;
    public GameObject fluidCollider;
    
    public float speed = 5f;
    public float jumpForce = 5f;
    
    public float walkableAngle = 45f;
    
    private Vector2 _input;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
        
        
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
            
        if (Input.GetKeyDown(KeyCode.W))
            Jump();
        
;
        if (Input.GetKeyDown(KeyCode.S))
            GoDownInWater();
        if (Input.GetKeyUp(KeyCode.S))
            fluidCollider.SetActive(true);
    }
    
    private void GoDownInWater()
    {
        fluidCollider.SetActive(false);
        _rb.velocity = new Vector2(_rb.velocity.x, -speed);
    }
    
    private void FixedUpdate()
    {
        Move();
    }
    
    private void Move()
    {
        _rb.velocity = new Vector2(_input.x * speed, _rb.velocity.y);
    }
    
    private void Jump()
    {
        if (IsGrounded())
            _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    
    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f);
        if (hit.collider != null)
        {
            float angle = Vector2.Angle(hit.normal, Vector2.up);
            if (angle < walkableAngle)
                return true;
        }
        return false;
    }
}