using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    // Variables 
    //public or private, type, name, value
    // public float speed = 3.5f; 
    // public float jumpForce = 5.0f; 
    // public bool isGrounded = false; // public bool isGrounded = false;
    // public bool doubleJump = false; // public bool doubleJump = false;
    // public Transform groundCheck; // public Transform groundCheck;
    // public LayerMask groundLayer; // public LayerMask groundLayer;
    // public Rigidbody2D rb; // public Rigidbody2D rb;
    // public Animator anim; // public Animator anim;
    // public Collider2D coll; // public Collider2D coll;
    // public int cherries = 0; // public int cherries = 0;
    // public Text cherryText; // public Text cherryText;
    // public Text livesText; // public Text livesText;
    // public int lives = 3; // public int lives = 3;
    // public AudioSource cherry; // public AudioSource cherry;
    // public AudioSource footstep; // public AudioSource footstep;
    // public AudioSource jump; // public AudioSource jump;
    // public AudioSource hit; // public AudioSource hit;
    // public AudioSource gameover; // public AudioSource gameover;
    // public AudioSource win; // public AudioSource win;
    // public AudioSource bgm; // public AudioSource bgm;

    // data type - int, float, bool, string
    // every variable has a name
    // optional value assigned

    // public float speed = 3.5f;
    [SerializeField]
    private float speed = 3.5f;

    

    // Start is called before the first frame update
    void Start()
    {
        //take the current position = new position (0, 0, 0)
        //transform.position.y - to find the actuall position, use vector 3
        transform.position = new Vector3(0, 0, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        
        //Goes straight to the right. I can also use the code below to specify an specific vector setting
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        //transform.Translate(new Vector3(5, 0, 0) * 5 * real time);

        



    }
}
