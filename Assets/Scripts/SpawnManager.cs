using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject[] powerups;    
    private bool _stopSpawning = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnPowerupRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // spawn game objects evry 5 secs
    // create a coroutine of type IEnumerator - Yield Events
    // while loop
    // instantiate enemy prefab
    // yield wait for 5 secs
    IEnumerator SpawnEnemy()
    {
        while (_stopSpawning == false)
        {
            GameObject newEnemy =  Instantiate(_enemyPrefab, new Vector3(Random.Range(-8f, 8f), 7, 0), Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator SpawnPowerupRoutine()
    {
        while (_stopSpawning == false)
        {            
            int randomPowerUp = Random.Range(0, 2);
            GameObject newPowerup = Instantiate(powerups[randomPowerUp], new Vector3(Random.Range(-8f, 8f), 7, 0), Quaternion.identity);           
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);            
            yield return new WaitForSeconds(Random.Range(3, 8));
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
