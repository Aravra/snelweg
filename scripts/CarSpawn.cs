using System.Collections;

using System.Collections.Generic;

using UnityEngine;

public class CarSpawn : MonoBehaviour

{

    [SerializeField] private GameObject prefab;
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] public int MaxNumberOfCars;
    [SerializeField] private float WaitTime;

    [HideInInspector]
    public int NumberOfCarsOnTheRoad = 0;

    private int SpawnTimer = 0;

    

    IEnumerator SpawnACar()
    {
        while (true)
        {
            while (NumberOfCarsOnTheRoad < MaxNumberOfCars)

            {
            if (SpawnTimer % 2 == 0)
            {
                Instantiate(prefab, new Vector3(5000f, 1f, 400f), Quaternion.Euler(0, -42.8f, 0), this.transform);
            }
            
            else
            {
                //Instantiate(prefab, new Vector3(0f, 1f, 0f), Quaternion.Euler(0, 90, 0));
                Instantiate(prefab, new Vector3(4980f, 1f, 414.7f), Quaternion.Euler(0, -42.8f, 0));
            }

            //Instantiate(prefab, spawnPosition, startRotation);

            //SpawnTimer++;
            NumberOfCarsOnTheRoad++;

            yield return new WaitForSeconds(WaitTime);
            }
        }
        

    }
    IEnumerator waittime()
    {
        yield return new WaitForSeconds(WaitTime);
    }
    public void Start()

    {
        StartCoroutine(waittime());
        
        StartCoroutine(SpawnACar());
        
    }


}
