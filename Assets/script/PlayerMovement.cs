using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Transform groundCheckPosition;
    public LayerMask groundLayer;
    public float jumpPower =  5f;
    public Animator anim;
    

    private bool isJumpping;
    private Rigidbody2D myBody;
    private bool isGrounded;
    private bool jumped;
    //*************************
    
    void Awake(){
        myBody = GetComponent<Rigidbody2D>();
    }
    
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
        CheckIfGrounded();
        PlayerJump();

      
    }

    void FixedUpdate(){
        PlayerWalk();

    }
        

    void PlayerWalk(){ //andar
        float h = Input.GetAxisRaw ("Horizontal");
          if (h > 0){
              myBody.velocity = new Vector2(speed, myBody.velocity.y);
              ChangeDirection(1f);
              
          } else if (h < 0){
              myBody.velocity = new Vector2(-speed, myBody.velocity.y);
              ChangeDirection(-1f);
          } else{
              myBody.velocity = new Vector2(0f, myBody.velocity.y);
          }
          anim.SetInteger("Speed",Mathf.Abs((int)myBody.velocity.x));
    }

    
    
    void ChangeDirection(float direction){ //muda a possisao do personagem x- x+
        Vector3 tempScale = transform.localScale;
        tempScale.x = direction;
        transform.localScale = tempScale;

    }

    
    
    void PlayerJump(){//pular
        if (isGrounded){
            if (Input.GetKey (KeyCode.Space)) {
                jumped = true;
                anim.SetBool("Jump",true);
                myBody.velocity = new Vector2 (myBody.velocity.x, jumpPower);
                 
               
               
                  }
            }
                 
        }
                      
    
    
    void CheckIfGrounded(){//check se ta no chao
        isGrounded = Physics2D.Raycast(groundCheckPosition.position, Vector2.down, 0.05f, groundLayer);
        if (isGrounded){
            if(jumped){


                jumped = false;
                anim.SetBool("Jump",false);
            }
        }
    }


    




    

   
   
   
   
   
   
   
   
   
   
   
}//class

