using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;
    // declare compnent
    private float movementX;
    //private float movementY;
    [SerializeField]
    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private Animator anim;
    private string WALK_ANIMATION = "Walk2";
    //public float maxVelocity = 22f;
    // Start is called before the first frame update

    private bool isGrounded;
    private string GROUND_TAG = "Ground";

    private string ENEMY_TAG = "Enemy";
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
    }
    private void FixedUpdate()
    {
        PlayerJump();
    }
    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
        //movementY = Input.GetAxisRaw("Vertical");
        //transform.position += new Vector3(0f, movementY, 0f) * Time.deltaTime * moveForce;
    }

    void AnimatePlayer()
    {
        //go right
        if (movementX > 0f)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        else if (movementX < 0f)
        { /*go left*/
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else /* when stop*/
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }
    void PlayerJump()
    {
        if (Input.GetButton("Jump")&& isGrounded)
        {
            isGrounded = false; 
            myBody.AddForce(new Vector2 (0f,jumpForce),ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) //xac dinh vacham
    {
        if (collision.gameObject.CompareTag(GROUND_TAG)){
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy (gameObject);
        }

    }
}//class
