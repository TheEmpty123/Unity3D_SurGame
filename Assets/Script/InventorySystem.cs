using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{

    public static InventorySystem instance { get; set; }

    public GameObject inventoryScreenUI;
    
    public List<GameObject> inventoryList = new List<GameObject>();
    public List<string> itemList = new List<string>();

    private GameObject item;
    private GameObject slot;

    //public bool isFull;
    public bool isOpen;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        //isFull = false;
        populateSlotList();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab) && !isOpen)
        {
            //Debug.Log("open inventory");
            inventoryScreenUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            isOpen = true;
        }
        else if ((Input.GetKeyDown(KeyCode.Tab)|| Input.GetKeyDown(KeyCode.Escape)) && isOpen)
        {
            Cursor.lockState = CursorLockMode.Locked;
            inventoryScreenUI.SetActive(false);
            isOpen = false;
        }
    }

    public void addItemToInventory(string itemName)
    {
        Debug.Log(itemName);
        slot = findEmptySlot();
        item = Instantiate(Resources.Load<GameObject>(itemName));
        item.transform.SetParent(slot.transform, false);
        itemList.Add(itemName);
    }

    private GameObject findEmptySlot()
    {
        foreach (GameObject item in inventoryList)
        {
            if (item.transform.childCount == 0)
            {
                return item;
            }
        }
        return new GameObject();
    }

    public bool checkFullInv()
    {
        foreach (GameObject item in inventoryList)
        {
            if (item.transform.childCount == 0)
                return false;
        }
        return true;
    }

    private void populateSlotList()
    {
        inventoryList.Clear();
        itemList.Clear();
        foreach( Transform child in inventoryScreenUI.transform)
        {
            if (child.CompareTag("Inventory Slot")) inventoryList.Add(child.gameObject);
        }
    }
}
