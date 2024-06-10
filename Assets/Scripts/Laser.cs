using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // speed variable of 8
    [SerializeField]
    private float _speed = 8.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

<<<<<<< HEAD
  // Update is called once per frame
  void Update()
  {
    // translate laser up
    transform.Translate(Vector3.up * _speed * Time.deltaTime);

    // if laser position is grader than 8 on the y, we need to destroy the object
    if (transform.position.y > 8f)
    {
      Destroy(this.gameObject);
    }

=======
    // Update is called once per frame
    void Update()
    {
      transform.Translate(Vector3.up * _speed * Time.deltaTime);  
>>>>>>> 1c77c0214e6a7b5a8f574e9c6320d1c204dd94a6
    }   
}
