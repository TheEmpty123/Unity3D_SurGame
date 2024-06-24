using System.Collections.Generic;
using UnityEngine;

public class GlobalResourceManager : MonoBehaviour
{
    public static GlobalResourceManager Instance;

    private List<GameObject> resources = new List<GameObject>();

    public int chunkIndex = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterResources(GameObject manager)
    {
        resources.Add(manager);
    }

    public List<GameObject> GetResources()
    {
        return resources;
    }


}
