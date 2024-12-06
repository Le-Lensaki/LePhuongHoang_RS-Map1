using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "SO/Level")]
public class LevelSO : ScriptableObject
{
    [SerializeField] protected List<StatusCat> listStatusCatSpawn;

    public List<StatusCat> GetListStatusCatSpawn => listStatusCatSpawn;


    [SerializeField] protected List<StatusCar> listStatusCarSpawn;

    public List<StatusCar> GetListStatusCarSpawn => listStatusCarSpawn;
}
