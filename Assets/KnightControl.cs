using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class KnightControl : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce;

    private float moveInput;
    public float runFactor;

    private Animator anim;
    private Rigidbody2D rb;

    public Joystick joystick;
   

    public Transform groundPos;
    public bool isGrounded;
    public float checkRadius;
    public LayerMask whatIsGround;

    [SerializeField] int jumpCounter;
    [SerializeField] int jumpTimes;
    private bool isJumping;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();    
        
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundPos.position, checkRadius, whatIsGround);
    }


    void Update()
    {
        Run();
        Jump();
       
        
       
    }

    public void Jump()
    {
        if (isGrounded == true && CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x , jumpForce);
            anim.SetTrigger("takeOff");
            isJumping = true;
        }
        if (isGrounded == true)
        {
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
        }
    }

    void Run()
    {
        moveInput = joystick.Horizontal;
        if (moveInput <0.2f  & moveInput >-0.2f)
        {
            runFactor = 0;
        }
        else if (moveInput >=0.2f)
        {
            runFactor = 1;
        }
        else if (moveInput <= -0.2f)
        {
            runFactor = -1;
        }
        
        //comment




        
      rb.velocity = new Vector2(runFactor * speed * Time.deltaTime, rb.velocity.y);
        

        if (runFactor == 0)
        {
            anim.SetBool("isRunning", false);
            
        }
        else if (moveInput >2f || moveInput <2f)
        {
            anim.SetBool("isRunning", true);
            



        }


        if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

    }
}
