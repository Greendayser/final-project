using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicObject : MonoBehaviour
{
     CharacterController characterController;

    public float vitesse = 15.0f;
    public Rigidbody2D rb2d;
    public float maxJump = 70.5f;
    private bool isGrounded = false;
    //public float jumpSpeed;
    //public float gravity = 20.0f;
   // private Vector2 moveDirection = Vector2.zero;

    

    // Start is called before the first frame update
    void Start()
    {
        
        rb2d.velocity +=new Vector2(vitesse, 0);
        //characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    { 
        if(Input.GetKeyDown("space") && isGrounded){
            Jump();
        }
         /*  if (characterController.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            moveDirection *= vitesse;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

         moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);*/
    }
     void Jump(){
          rb2d.velocity +=new Vector2(0,maxJump);
     }

      void OnCollisionEnter2D(Collision2D col) {
         if (col.gameObject.CompareTag("Ground"))
         {
             isGrounded = true;
         }
          
      }

     void OnCollisionExit2D(Collision2D col) {

           if (col.gameObject.CompareTag("Ground"))
         {
             isGrounded = false;
         }
      }

}
