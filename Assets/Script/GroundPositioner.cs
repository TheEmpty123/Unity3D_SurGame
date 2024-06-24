using System.Collections;
using UnityEngine;

public class GroundPositioner : MonoBehaviour
{
    bool active = false;

    void Start()
    {
        StartCoroutine(WaitFunction(1));
    }

    void Update()
    {
        if (gameObject.activeSelf && !active)
        {
            PlaceOnMeshGround();
            active = true;
        }
    }

    void PlaceOnMeshGround()
    {

        RaycastHit hit;
        // Cast a ray downward from the object's position
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity))
        {
            transform.position = hit.point;
        }
    }

    IEnumerator WaitFunction(float time)
    {
        yield return new WaitForSeconds(time);
        // Code to execute after the wait
        PlaceOnMeshGround();
        this.gameObject.SetActive(false);
    }

}
