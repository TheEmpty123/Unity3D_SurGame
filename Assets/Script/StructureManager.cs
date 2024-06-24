using System;
using UnityEngine;

public class StructureManager : MonoBehaviour
{
    [Serializable]
    public class WeightedSpawn
    {
        public GameObject prefab;
        public float weight;
    }

    public WeightedSpawn[] structurePrefabs;

    public float totalWeight { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
        calculateTotalWeight();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

/*
    public GameObject findStructureToSpawn(GameObject[] obj)
    {

        int index = Random.Range(0, obj.Length - 1);

        GameObject structureToSpawn = obj[index];

        return structureToSpawn;
    }
*/
    
    public void calculateTotalWeight()
    {
        totalWeight = 0f;
        WeightedSpawn[] array = structurePrefabs;
        foreach (var weightedSpawn in array)
        {
            totalWeight += weightedSpawn.weight;
        }
    }

}
