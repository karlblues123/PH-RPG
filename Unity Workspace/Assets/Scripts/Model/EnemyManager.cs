using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public List<GameObject> poolers;


    public void MakeEnemyPooler (GameObject enemyPrefab, int poolsize)
    {
        GameObject pool = new GameObject();
        pool.AddComponent<ObjectPooler>();
        pool.GetComponent<ObjectPooler>().RegisterPrefab(enemyPrefab);
        pool.GetComponent<ObjectPooler>().SetPoolSize(poolsize);
        poolers.Add(pool);
    }

    /*
        Place Enemies based on the input
    */
    public void PlaceEnemies (int enemyIndex, int numberOfEnemies)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            poolers[enemyIndex].GetComponent<ObjectPooler>().GetAvailable();
            //Put enemies
        }
        
    }
}
