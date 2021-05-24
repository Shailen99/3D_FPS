using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public CharacterController control;
  public float speed;
  public float walkSpeed = 8f;
  public float gravity = -9.81f;

  public float sprintSpeed = 12f;
   Vector3 velocity;
   bool isGrounded;

   public Transform groundCheck;
   public float groundDistance = 0.4f;
   public LayerMask groundMask;

   public float jumpHeight = 3f;
    // Update is called once per frame
    void Update()
    {
      speed = walkSpeed;


      //Check if player is grounedd
      isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
      if(isGrounded && velocity.y < 0)
      {
        velocity.y = -2f;
        if(Input.GetKey(KeyCode.LeftShift))
        {
          speed = sprintSpeed;
        }
        else{
          speed = walkSpeed;
        }
      }

      float x = Input.GetAxisRaw("Horizontal");
      float z = Input.GetAxisRaw("Vertical");

      Vector3 move = transform.right * x + transform.forward * z;

      control.Move(move * speed * Time.deltaTime);

            //Jump
        if(isGrounded && Input.GetButtonDown("Jump"))
          {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
          }
      velocity.y += gravity * Time.deltaTime;

      control.Move(velocity * Time.deltaTime);

      //Sprint

    }
}
