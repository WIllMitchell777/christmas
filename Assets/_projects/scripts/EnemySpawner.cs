using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public GameObject EnemyPrefab2;
    public float Cooldown;
    public bool SpawnBothEnemies;
    System.Random RNG = new();

    IEnumerator Start()
    {
        while (true)
        {
            //Spawn Enemy
            if (SpawnBothEnemies)
            {
                int RandomNumber = RNG.Next(1,3);
                GameObject NewEnemy;
                switch(RandomNumber)
                {
                    case 1:
                        NewEnemy = Instantiate(EnemyPrefab);
                        NewEnemy.transform.position = gameObject.transform.position + new Vector3(((float)RNG.Next(-10,10))/10, ((float)RNG.Next(-10,10))/10, ((float)RNG.Next(-10,10))/10);
                        NewEnemy.transform.rotation = gameObject.transform.rotation;
                        break;
                    case 2:
                        NewEnemy = Instantiate(EnemyPrefab2);
                        NewEnemy.transform.position = gameObject.transform.position;
                        NewEnemy.transform.rotation = gameObject.transform.rotation;
                        break;
                }
            }
            else
            {
                GameObject NewEnemy = Instantiate(EnemyPrefab);
                NewEnemy.transform.position = gameObject.transform.position;
                NewEnemy.transform.rotation = gameObject.transform.rotation;
            }
            yield return new WaitForSeconds(Cooldown);
        }
    }
}
