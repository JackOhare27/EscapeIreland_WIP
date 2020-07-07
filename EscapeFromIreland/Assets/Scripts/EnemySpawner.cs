using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //For Enemies
    public GameObject enemy;
    public int numberOfEnemies;

    //For Pub
    public int PubAmount;
    public GameObject Pub;
    private GameObject PubPos;
    public bool pubActivate = false;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Summons Pubs
        PubRiser();
        //Used to find the exact position of the pubs
        PubPos = GameObject.FindGameObjectWithTag("Pub");
        //How many pubs are there
        PubAmount = GameObject.FindGameObjectsWithTag("Pub").Length;
   

        //Looks for amount of objects
        numberOfEnemies = FindObjectsOfType<EnemyController>().Length;

        if(numberOfEnemies == 0 && PubAmount == 1)
        {
         
            pubActivate = true;
            if (PubPos.transform.position.y >= 4)
            {

                Spawner(RandomEnemyGenerator());

            }
            

        }
    }

    Vector3 SpawnLocation()
    {
        Vector3 RandomLocation = new Vector3(Random.Range(-3,-10), 0, Random.Range(-13, 13));
        return RandomLocation;
    }
    
    //Controls enemies spawned
    void Spawner(int enemiesSpawned)
    {
       
        for (int i = 0; i < enemiesSpawned; i++)
        {
            Instantiate(enemy, SpawnLocation(), enemy.transform.rotation);
        }
    }

    //Controls summoning of pubs
    void PubRiser()
    {
        //gives new position for pub
        Vector3 randomPubPos = new Vector3(Random.Range(-13, 13), -10, Random.Range(12, 0));
        
        if(PubAmount == 0)
        {
            Instantiate(Pub, randomPubPos, transform.rotation);
        }
    }

    int RandomEnemyGenerator()
    {
        int enemyAmountGenerator = Random.Range(1, 5);
        return enemyAmountGenerator;

    }
}
