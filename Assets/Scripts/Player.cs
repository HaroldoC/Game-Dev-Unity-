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
    [SerializeField]
    private GameObject _laserPrefab;
<<<<<<< HEAD
    [SerializeField]
    private float _fireRate = 0.5f;    
    private float _canFire = -1f;
    [SerializeField]
    private int _lives = 3;

=======
>>>>>>> 1c77c0214e6a7b5a8f574e9c6320d1c204dd94a6


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
        CalculateMovement();
<<<<<<< HEAD
        FireLaser();
=======
<<<<<<< HEAD

        // if I hit sapce bar, will spawn gameObject
        // CalculateFire();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            // Debug.Log("Sapce Key Pressed");
            Instantiate(_laserPrefab, transform.position, Quaternion.identity);
        }
=======
>>>>>>> dae734debba66823f9f189e9bb1f3d3da3f9d0f5
>>>>>>> 1c77c0214e6a7b5a8f574e9c6320d1c204dd94a6
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //Goes straight to the right. I can also use the code below to specify an specific vector setting
        // transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        // transform.Translate(Vector3.up * verticalInput * speed * Time.deltaTime);

        //transform.Translate(new Vector3(5, 0, 0) * 5 * real time);


        //One line code for a cleaner and better understanding 
        transform.Translate(speed * Time.deltaTime * new Vector3(horizontalInput, verticalInput, 0));
<<<<<<< HEAD

        //If player position on the y is greater than 0
        //y position = 0

        // float a = 5;
        // float b = 10;

        if (transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y <= -3.8f)
        {
            transform.position = new Vector3(transform.position.x, -3.8f, 0);
        }

        //Clamping method
        // transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0), 0);
<<<<<<< HEAD

=======
=======
>>>>>>> dae734debba66823f9f189e9bb1f3d3da3f9d0f5

        //If player position on the y is greater than 0
        //y position = 0

<<<<<<< HEAD
=======
        // float a = 5;
        // float b = 10;

        if (transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y <= -3.8f)
        {
            transform.position = new Vector3(transform.position.x, -3.8f, 0);
        }

>>>>>>> dae734debba66823f9f189e9bb1f3d3da3f9d0f5
>>>>>>> 1c77c0214e6a7b5a8f574e9c6320d1c204dd94a6
        // if player on the x > 11
        // x position = -11
        if (transform.position.x > 11f)
        {
            transform.position = new Vector3(-11f, transform.position.y, 0);
        }
        else if (transform.position.x < -11f)
        {
            transform.position = new Vector3(11f, transform.position.y, 0);
        }
    }

    void FireLaser()
    {
        // if I hit sapce bar, will spawn gameObject
        // CalculateFire();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            _canFire = Time.time + _fireRate;
            // Debug.Log("Sapce Key Pressed");
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
        }
    }

    public void Damage()
    {
        _lives--;
        
        if (_lives < 1)
        {
            Destroy(this.gameObject);
        }
    }
}
