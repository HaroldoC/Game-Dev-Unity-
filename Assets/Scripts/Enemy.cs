using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;
    [SerializeField]
    private Player _player;
    private Animator _anim;


    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();

        if (_player == null)
        {
            Debug.Log("The Player is NULL");
        }

        _anim = GetComponent<Animator>();

        if (_anim == null)
        {
            Debug.Log("The Animator is NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // move the enemy down 4 m per s
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        // if bottom of the screen, respawn back up top with a new random x position
        if (transform.position.y < -5f)
        {
            float randomX = Random.Range(-8f, 8f);
            transform.position = new Vector3(randomX, 7, 0);
        }

        // if the enemy position on the y is less than -8, destroy the object
        // Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // if other is the player
        // damage the player
        // destroy us
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();

            if (_player != null)
            {
                player.Damage();
            }
            _anim.SetTrigger("OnEnemyDeath");
            _speed = 0;
            Destroy(this.gameObject, 2.4f);
        }

        // if other is Laser
        // destroy the laser
        // destroy us
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            // int points = 10; 
            if (_player != null)
            {
                _player.AddScore(10);
            }
            _anim.SetTrigger("OnEnemyDeath");
            _speed = 0;
            Destroy(this.gameObject, 2.4f);
        }
    }
}
