using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string itemName;
    public bool playerInRange;

    public string getItemName()
    {
        return itemName;
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && playerInRange && SelectionManager.instance.onTarget && SelectionManager.instance.targetItem == gameObject)
        {
            Debug.Log("Clicked!");
            //If inventory is not full
            if(!InventorySystem.instance.checkFullInv())
            {
                InventorySystem.instance.addItemToInventory(itemName);
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Inventory Full!");
            }
        } 
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

        }
    }
}
