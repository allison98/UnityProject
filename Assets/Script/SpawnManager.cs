using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int min = 0;
    public int max = 40;
    public List<GameObject> flower;
    public List<GameObject> enemy;

    private float spaceBetweenSquares = 2.5f;
    private float minValueX = 0;
    private float minValueZ = 0;


    // Start is called before the first frame update
    void Start()

    {
        int numberOfFlowers = Random.Range(min, max);
        for (int i = 0; i<max; i++)
        {
            int randomInt = Random.Range(0, 3);
        
            Instantiate(flower[randomInt], RandomSpawnPosition(), flower[randomInt].transform.rotation);
        }

        InvokeRepeating("spawnEnemies", 2, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnEnemies() { 
    
        int randomInt = Random.Range(0, 2);
        Instantiate(enemy[randomInt], RandomEnemyPosition(randomInt), enemy[randomInt].transform.rotation);
    }

    // Spawn in random Location
    Vector3 RandomSpawnPosition()
    {
        float spawnPosX = minValueX + (RandomSquareIndex(-6.0f, 6.0f) * spaceBetweenSquares);
        float spawnPosZ = minValueZ + (RandomSquareIndex(-6.0f, 6.0f) * spaceBetweenSquares);

        Vector3 spawnPosition = new Vector3(spawnPosX, 0.8f, spawnPosZ);
        return spawnPosition;

    }

    Vector3 RandomEnemyPosition(int direction)
    {
        float spawnPos = RandomSquareIndex(-14,14);

        if (direction == 0)
        {
            Vector3 spawnPosition = new Vector3(-23f, 0.1f, spawnPos);
            return spawnPosition;

        }
        else
        {
            Vector3 spawnPosition = new Vector3(spawnPos, 0.1f, 23);
            return spawnPosition;

        }
        

    }

    float RandomSquareIndex(float start, float end)
    {
        return Random.Range(start, end);
    }
}
