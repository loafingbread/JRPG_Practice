using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Inventory")]
public class Inventory : ScriptableObject
{
    public ItemRecipeSet itemRecipes;
    //Game save Data
    public int money;
    
    public List<Item> consumables = new List<Item>();
    
    public bool BuyItem(ItemRecipe item, int buyAmount)
    {
        int itemCost = item.ItemCost(buyAmount);
        if(money >= itemCost)
        {
            money -= itemCost;
            UpdateCount(item, buyAmount);
            return true;
        }
        else
        {
            return false;
        }
    }

    public int UpdateCount(ItemRecipe item, int itemAmount)
    {
        for (int i = 0; i < consumables.Count; i++)
        {
            Item consumable = consumables[i];
            if( item.itemName == consumable.itemName)
            {
                consumable.UpdateCount(itemAmount);
                return consumable.count;
            }
            
        }
        //usually, item.itemcountrange.minvalue will be 0. 
        if(itemAmount > item.itemCountRange.minValue)
        {
            //the "item" in New Item("item", itemAmount), is a reference to "ItemRecipe item"
            Item newItem = new Item(item, itemAmount);
            consumables.Add(newItem);
        }
        return -1;
    }
    
}
