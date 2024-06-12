using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // move the enemy down 4 m per s
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        // if bottom of the screen, respawn back up top with a new random x position
        if (transform.position.y < -5f)
        {
            transform.position = new Vector3(Random.Range(-8f, 8f), 7, 0);

        }

        // if the enemy position on the y is less than -8, destroy the object
        // Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // if other is the player
        // damage the player
        // destroy us
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }

            Destroy(this.gameObject);
        }

        // if other is Laser
        // destroy the laser
        // destroy us
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
