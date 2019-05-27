using UnityEngine;
using System.Collections;

public class playermouv2 : MonoBehaviour
{

    public float speed;             //Floating point variable to store the player's movement speed.
    public float jumpForce;
    private float movInput;
    private Rigidbody2D rb2d;
    private bool facingright = true;
    private Animator anim;

    
 

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
       
        movInput = Input.GetAxis("Horizontal");
        if(movInput != 0)
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
        rb2d.velocity = new Vector2(movInput * speed , rb2d.velocity.y);

        if(Input.GetKey(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
        }
        
        if(facingright == false && movInput > 0)
        {
            flip();
        }
        else if(facingright == true && movInput <0)
        {
            flip();
        }
    }
    void flip()
    {
        facingright = !facingright;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
        anim.SetTrigger("Run");

    }
    
}