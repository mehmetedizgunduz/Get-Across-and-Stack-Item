using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CarSpawnLeft : MonoBehaviour
{
    public float spawntime = 1;
    private float timer = 0;
    public GameObject[] cars;
    public Transform Spawner;
    void Start()
    {
        //RANDOM SPAWNER 
        int prefabIndex = UnityEngine.Random.Range(0, cars.Length);
        GameObject newcar = Instantiate(cars[prefabIndex]);
        newcar.transform.position = Spawner.transform.position;
        Destroy(newcar, 5);

        //SINGLE SPAWNER 
        //GameObject newcar = Instantiate(car);
        //newcar.transform.position = new Vector3(-24f, 0.5f, -3f);
        //Destroy(newcar, 10);
    }
    void Update()
    {
        //RANDOM SPAWNER 
        int prefabIndex = UnityEngine.Random.Range(0, cars.Length);
        if (timer > spawntime)
        {
            GameObject newcar = Instantiate(cars[prefabIndex]);
            newcar.transform.position = Spawner.transform.position;
            Destroy(newcar, 5);
            timer = 0;

            //SINGLE SPAWNER 
            //GameObject newcar = Instantiate(car);
            //newcar.transform.position = new Vector3(-24f, 0.5f, -3f);
            //Destroy(newcar, 10);
            //timer = 0;
        }
        timer += Time.deltaTime;
    }
}
