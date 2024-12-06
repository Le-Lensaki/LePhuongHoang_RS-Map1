using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : Spawner
{
    [SerializeField] protected const float radiusCircle = 10f;
    protected Vector3 GenerateRandomPosition(Vector3 posCenter)
    {
        float angle = Random.Range(0f, Mathf.PI * 2);

        float x = Mathf.Cos(angle) * Random.Range(0f, radiusCircle);
        float z = Mathf.Sin(angle) * Random.Range(0f, radiusCircle);

        return new Vector3(posCenter.x + x, posCenter.y, posCenter.z + z);
    }


    public void SpawnCar(string namePrefab, Vector3 posCenter)
    {
        Transform transform = this.Spawn(namePrefab, GenerateRandomPosition(posCenter));
    }
}
