using UnityEngine;

public class ResoucesGenerator : MonoBehaviour
{
    [SerializeField]
    int maxN = 250;
    int density = 1;

    float chunkSize = 476f;
    float totalWeight;

    Vector3 localPos;

    public StructureManager.WeightedSpawn[] resourcePrefabs;

    public ConsistentRandom randomGen;

    // Start is called before the first frame update
    void Start()
    {
        Transform parent = transform.parent.parent;
        localPos = parent.transform.position;

        randomGen = new ConsistentRandom(MapManager.getSeed());

        StructureManager.WeightedSpawn[] array = resourcePrefabs;

        foreach (StructureManager.WeightedSpawn s in array)
        {
            totalWeight += s.weight;
        }

        if(resourcePrefabs != null || resourcePrefabs.Length == 0)
        {
            spawn();
        }

    }

    public void spawn()
    {
        float x, z;
        for (int i = 0; i < maxN; i += density)
        {
/*
            Quaternion rotation = Quaternion.Euler((float)(randomGen.NextDouble() - 0.5) * 2f, (float)(randomGen.NextDouble() - 0.5) * 2f, (float)(randomGen.NextDouble() - 0.5) * 2f);
*/
            x = (float)(randomGen.NextDouble() * (chunkSize) + localPos.x);
            z = (float)(randomGen.NextDouble() * (chunkSize) + localPos.z);

            Vector3 pos = new Vector3(x, 100, z);

            var obj = (GameObject)Instantiate(findObjectToSpawn(resourcePrefabs, totalWeight), pos, Quaternion.identity) as GameObject;

            obj.transform.SetParent(transform);

            GlobalResourceManager.Instance.RegisterResources(obj);
        }
    }

    private GameObject findObjectToSpawn(StructureManager.WeightedSpawn[] structurePrefabs, float totalWeight)
    {
        float num = (float)randomGen.NextDouble();
        float num2 = 0f;

        for (int i = 0; i < structurePrefabs.Length; i++)
        {
            num2 += structurePrefabs[i].weight;
            if (num < num2 / totalWeight)
            {
                return structurePrefabs[i].prefab;
            }
        }

        return structurePrefabs[0].prefab;

    }

}
