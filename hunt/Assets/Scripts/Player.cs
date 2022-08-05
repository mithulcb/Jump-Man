using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 11f;


    private float movementX;

    private Rigidbody2D myBody;

    private SpriteRenderer sr;

    private Animator anim;

    private string WALK_ANIMATION = "Walk";

    private string GROUND_TAG = "Ground";

    private string ENEMY_TAG = "Enemy";

    private bool isGrounded;

    private int jump_cnt;

    private void Awake()
    {

        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyBoard();
        AnimatePlayer();
        PlayerJump();


    }

   
    

    void PlayerMoveKeyBoard()
    {

        movementX = Input.GetAxisRaw("Horizontal"); //returns input fmr keyboard . Diff b/w getaix and getaxis raw is in raw only 0,1,-1 rather than in getaxis where it increases and decreases
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
        
    }

    void AnimatePlayer()
    {

        if (movementX>0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        else if (movementX<0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else 
        {
            anim.SetBool(WALK_ANIMATION, false);
        }

    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump")  && jump_cnt!=2)
        {
            jump_cnt += 1;
            //isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            //isGrounded = true;
            jump_cnt = 0;
        }

        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
            
           

        }

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
            

        }
    }
} //class
