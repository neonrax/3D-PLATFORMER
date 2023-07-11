using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jumpForce = 5f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    private CapsuleCollider boxCollider;
    RaycastHit Hit;
    [SerializeField] Vector3 boxsize;
    [SerializeField] float maxdistance;

    [SerializeField] AudioSource jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        boxCollider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
            
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        jumpSound.Play();
    }

    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.CompareTag("Enemy"))
    //     {
    //         Destroy(collision.transform.parent.gameObject);
    //         Jump();
    //     }
    // }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
        
        
    }

      private bool isGroundedray()
    {   
        if(Physics.BoxCast(boxCollider.bounds.center,boxsize,-transform.up,transform.rotation,maxdistance,ground)) return true;
        else return false;
    }

    // private void OnDrawGizmos() {
    //     Gizmos.color=Color.red;
    //     Gizmos.DrawCube(transform.position -transform.up * maxdistance,boxsize);

        
    // }

}