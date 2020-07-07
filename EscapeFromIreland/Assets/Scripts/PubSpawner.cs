using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PubSpawner : MonoBehaviour
{
    public EnemySpawner EnemySpawner;
  
    // Start is called before the first frame update
    void Start()
    {
        EnemySpawner = GameObject.Find("Game Manager").GetComponent<EnemySpawner>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y <= 4 && EnemySpawner.pubActivate == true)
        {
            transform.Translate(Vector3.up * Time.deltaTime);
        }
    }
}
