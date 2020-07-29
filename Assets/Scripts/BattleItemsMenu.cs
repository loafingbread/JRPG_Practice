using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleItemsMenu : MonoBehaviour
{
    public Inventory playerInventory;
    public GameObject itemButton;
    // Start is called before the first frame update
    void Start()
    {
       foreach(Item consumableItem in playerInventory.consumables)
        {
            UnityEngine.Debug.Log("ConsumableItem: " + consumableItem.itemName);
            GameObject button = Instantiate(itemButton, gameObject.transform);
            button.transform.GetChild(0).gameObject.GetComponent<Text>().text = consumableItem.itemName;
            button.transform.GetChild(1).gameObject.GetComponent<Text>().text = consumableItem.count.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
