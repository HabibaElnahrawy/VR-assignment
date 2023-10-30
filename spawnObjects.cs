using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObjects : MonoBehaviour
{
    int cubePrefab_nb=0;
        public GameObject cubePrefab;
        void Update()
        {
            if (cubePrefab_nb<10)
            {
            Instantiate(cubePrefab, new Vector3(Random.Range(-19, -7), Random.Range(2, 0.1f), 0), Quaternion.identity);
            cubePrefab_nb++;
            }
        }
    
}
