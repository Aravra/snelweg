using System.Collections;

using System.Collections.Generic;

using UnityEngine;

public class CarSpawn : MonoBehaviour

{

    [SerializeField] private GameObject prefab;
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] public int MaxNumberOfCars;

    [HideInInspector]
    public int NumberOfCarsOnTheRoad = 0;

    Quaternion startRotation = Quaternion.LookRotation( new Vector3(10, 0, 0), Vector3.up);


    IEnumerator SpawnACar()
    {
        
        while (NumberOfCarsOnTheRoad < MaxNumberOfCars)

        {
            Instantiate(prefab, spawnPosition, startRotation);

            NumberOfCarsOnTheRoad++;

            yield return new WaitForSeconds(2.5f);
        }

    }
    IEnumerator waittime()
    {
        yield return new WaitForSeconds(2.5f);
    }
    public void Start()

    {
        StartCoroutine(waittime());
        StartCoroutine(SpawnACar());
    }

}
