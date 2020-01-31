using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9.0f;
    public GameObject powerupprefab;
    public int enemyCount;
    public  int wavenumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        spawnenemywave(wavenumber);
        Instantiate(powerupprefab, generatespawnposition(), powerupprefab.transform.rotation);
    }
    
    
    // dit werkt niet hij spawned dan niks meer (4.4)
    void Update()
    {
       /* { 
            enemyCount = FindObjectsOfType<Enemy>().Length;

            if (enemyCount == 0)
            {
                wavenumber++;
                spawnenemywave(wavenumber);
               
            } */
    } 

    void spawnenemywave(int enemiestospawn)
    {
        for (int i = 0; i < enemiestospawn; i++)
        {
            Instantiate(enemyPrefab, generatespawnposition(), enemyPrefab.transform.rotation);
        }
    }

    // Update is called once per frame

    private Vector3 generatespawnposition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        
        Vector3 randomPos = new Vector3(spawnPosX,0, spawnPosZ);

        return randomPos;
    }
   } 
    

