using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    private float _speed = 3.0f;
    // ID for powerups
    // 0 = Triple Shot
    // 1 = Speed
    // 2 = Shields
    [SerializeField]
    private int powerupID;
    // private bool isCollected = false;
    // private PlayerController playerController;
    // private AudioSource _audioSource;
    // [SerializeField]
    // private AudioClip _clip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.Translate(Vector3.down * _speed * Time.deltaTime);

         if (transform.position.y < -4.5f)
         {
              Destroy(this.gameObject);
         } 
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                switch (powerupID)
                {
                    case 0:
                        player.TripleShotActive();
                        break;
                    case 1:
                        player.SpeedBoostActive();
                        break;
                    case 2:
                        player.ShieldBoostActive();
                        break;
                    default:
                        Debug.Log("Default Value");
                        break;                
                }                
            }         

            Destroy(this.gameObject);     
        }
    }    
}
