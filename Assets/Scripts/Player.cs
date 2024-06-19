using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{    
    [SerializeField]
    private float _speed = 3.5f;
    private float _speedMultiplier = 2;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    [SerializeField]
    private float _fireRate = 0.5f;    
    private float _canFire = -1f;
    [SerializeField]
    private int _lives = 3;    
    private Spawn_Manager _spawnManager;
    [SerializeField]
    private bool isTripleShotActive = false;
    [SerializeField]
    // private bool isShieldActive = false;
    private bool isSpeedBoostActive = false;
    private bool isShieldBoostActive = false;
    [SerializeField]
    private GameObject shieldVisualizer;
    [SerializeField]
    private int _score;
    private UIManager _uiManager;
    // private GameManager _gameManager;
    // private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        //take the current position = new position (0, 0, 0)
        //transform.position.y - to find the actuall position, use vector 3
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<Spawn_Manager>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (_spawnManager == null)
        {
            Debug.LogError("The Spawn Manager is NULL.");
        }
        if (_uiManager == null)
        {
            Debug.LogError("The UI Manager is NULL.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        FireLaser();

        // if I hit sapce bar, will spawn gameObject
        // CalculateFire();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            // Debug.Log("Sapce Key Pressed");
            Instantiate(_laserPrefab, transform.position, Quaternion.identity);
        }
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
        float currentSpeed = isSpeedBoostActive ? _speed * _speedMultiplier : _speed;
        transform.Translate(currentSpeed * Time.deltaTime * new Vector3(horizontalInput, verticalInput, 0)); 
        // transform.Translate(_speed * Time.deltaTime * new Vector3(horizontalInput, verticalInput, 0));

        // if (isSpeedBoostActive == false)
        // {
        //     _speed = 3.5f;
        // }
        // else
        // {
        //     _speed = 7.0f;
        // }

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
        //If player position on the y is greater than 0
        //y position = 0

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

        if (isTripleShotActive == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
            {
                _canFire = Time.time + _fireRate;
                Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
            {
                _canFire = Time.time + _fireRate;
                // Debug.Log("Sapce Key Pressed");
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.9f, 0), Quaternion.identity);
            }
        }        
    }

    public void Damage()
    {
        if (isShieldBoostActive == true)        
        {
            // Debug.Log("Shield is active");            
            isShieldBoostActive = false;
            shieldVisualizer.SetActive(false);
            return;
        }
        
        _lives--;
        // _livesText.text = "Lives: " + _lives;
        _uiManager.UpdateLives(_lives);
        
        if (_lives < 1)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }

    public void TripleShotActive()
    {
        isTripleShotActive = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }
    
    IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        isTripleShotActive = false;
    }

    public void SpeedBoostActive()
    {
        isSpeedBoostActive = true;
        _speed *= _speedMultiplier;
        StartCoroutine(SpeedBoostPowerDownRoutine());
    }

    IEnumerator SpeedBoostPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);        
        isSpeedBoostActive = false;
        _speed /= _speedMultiplier;

    }

    public void ShieldBoostActive()
    {
        isShieldBoostActive = true;
        shieldVisualizer.SetActive(true);
        // StartCoroutine(ShieldBoostPowerDownRoutine());
    }

    IEnumerator ShieldBoostPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        isShieldBoostActive = false;
    }

    public void AddScore(int points)
    {
        _score += points;
        _uiManager.UpdateScore(_score);
    }
}
