using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesActivator : MonoBehaviour
{

    public float activationRange = 100f;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = this.transform;
    }

    // Update is called once per frame

    void Update()
    {
        List<GameObject> list = GlobalResourceManager.Instance.GetResources();

        if (list != null)
        {
            foreach (GameObject obj in list)
            {
                if (obj == null) continue;

                Vector3 pos = new Vector3(obj.transform.position.x, player.transform.position.y, obj.transform.position.z);
                float distance = Vector3.Distance(player.transform.position, pos);

                obj.SetActive(distance <= activationRange);
            }
        }

    }

}
