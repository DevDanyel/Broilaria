using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplyer;
    //bool readyToJump;

    [Header("Key Bindings")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("ground check")]
    public float playerHeigt;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    public Rigidbody rb;

    private void start(){
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }    


    private void Update(){
        //ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeigt*.05f+0.2f, whatIsGround);

        MyInput();
        
        //handle drag
        if(grounded){
            rb.drag = groundDrag;
        }else{
            rb.drag =0;
        }

        SpeedControl();
        
    }

    private void FixedUpdate(){
        MovePlayer();
    }


    private void MyInput(){
        horizontalInput=Input.GetAxisRaw("Horizontal");
        verticalInput= Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer(){
        //calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right*horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void SpeedControl(){
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limit velocity if needed
        if(flatVel.magnitude > moveSpeed){
            Vector3 limitedVel = flatVel.normalized*moveSpeed;
            rb.velocity= new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump(){
        //reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

   /* private void ResetJump(){
        readyToJump = true;
    }*/
}
