using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
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
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerupRoutine());
    }

    // Update is called once per frame
    void Update()
    {
  
    }
    IEnumerator SpawnPowerupRoutine()
    {
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            Instantiate(powerups[Random.Range(0,2)], posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }


    }
    IEnumerator SpawnEnemyRoutine()
    {
        while (_stopSpawning==false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
           GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(3f);

        }
    }
   

    public void onPlayerDeath()
    {
        _stopSpawning = true;
    }
}
