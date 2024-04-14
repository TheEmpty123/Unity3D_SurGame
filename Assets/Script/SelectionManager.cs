using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{

    public static SelectionManager instance { get;set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            //Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public GameObject interaction_Info_UI;
    Text interaction_text;

    public bool onTarget;
    public GameObject targetItem;
    // Start is called before the first frame update
    void Start()
    {
        onTarget = false;
        interaction_text = interaction_Info_UI.GetComponent<Text>();   
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selectionTransform = hit.transform;
            InteractableObject interactableObj = selectionTransform.GetComponent<InteractableObject>();

            if (interactableObj && interactableObj.playerInRange) 
            {
                onTarget = true;
                targetItem = interactableObj.gameObject;
                interaction_text.text = interactableObj.getItemName();
                interaction_Info_UI.SetActive(true);
            }
            else
            {
                interaction_Info_UI.SetActive(false);
                onTarget = false;
            }
        }
        else
        {
            interaction_Info_UI.SetActive(false);
            onTarget = false;
        }
    }
}
