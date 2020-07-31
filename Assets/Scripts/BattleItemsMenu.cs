using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class BattleItemsMenu : MonoBehaviour
{
    public Inventory playerInventory;
    public BattleSystem battleSystem;
    public GameObject itemButton;
    private GridLayoutGroup gridLayout;
    private RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Item consumableItem in playerInventory.consumables)
        {
            UnityEngine.Debug.Log("ConsumableItem: " + consumableItem.itemName);
            GameObject button = Instantiate(itemButton, gameObject.transform);
            button.transform.GetChild(0).gameObject.GetComponent<Text>().text = consumableItem.itemName;
            button.transform.GetChild(1).gameObject.GetComponent<Text>().text = consumableItem.count.ToString();
            Button buttonComponent = button.GetComponent<Button>();
            buttonComponent.onClick.AddListener(OnItemButtonClick(consumableItem) );
        }
    }

    public UnityAction OnItemButtonClick(Item item)
    {
        return delegate ()
        {
            if (battleSystem)
            {
                battleSystem.OnPlayerUseItem(item);
            }
        };

    }

    public void Toggle()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        } else
        {
            gameObject.SetActive(true);
        }
    }

    private void OnEnable()
    {

        gridLayout = gameObject.GetComponent<GridLayoutGroup>();
        rectTransform = gameObject.GetComponent<RectTransform>();
        if (rectTransform)
        {
            LayoutRebuilder.MarkLayoutForRebuild(rectTransform);
        }
    }

    private void OnDisable()
    {
        gridLayout = null;
        rectTransform = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
