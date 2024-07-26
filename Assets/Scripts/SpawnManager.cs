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
    
    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnPowerupRoutine());       
    }    
    
    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(3.0f);
        
        while (_stopSpawning == false)
        {
            GameObject newEnemy =  Instantiate(_enemyPrefab, new Vector3(Random.Range(-8f, 8f), 7, 0), Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator SpawnPowerupRoutine()
    {
        yield return new WaitForSeconds(3.0f);

        while (_stopSpawning == false)
        {            
            int randomPowerUp = Random.Range(0, 3);
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
