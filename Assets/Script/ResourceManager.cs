using System.Collections;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public GameObject[] spawners;

    private void Awake()
    {
        StartCoroutine(GenerateResources());
    }


    private IEnumerator GenerateResources()
    {
        for (int i = 0;i < spawners.Length;i++)
        {
            spawners[i].SetActive(value: true);
        }

        yield return 3000;
    }
}
