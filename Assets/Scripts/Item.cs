﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item 
{
    // Item's default property values from its recipe
    private ItemRecipe recipe;
    public string itemName { get { return recipe.itemName; } }
    public string itemDescription { get { return recipe.itemDescription; } }
    public int baseCost { get { return recipe.itemCost; } }

    // Keep track of Item's per instance properties
    public int count { get; set; }
    // -1 is the default value, and if it is at -1, that means no count was passed in. 
    public Item(ItemRecipe recipe, int count = -1)
    {
        this.recipe = recipe;
        this.count = count == - 1 ? recipe.itemCountRange.defaultValue : count;
    }

    /***************************************************************************
     * Item Instance methods
     **************************************************************************/
    /**
     * <returns>Whether item is usable or not.</returns>
     */

    //minValue is usually set to 0, and default value for the count variable is set also set to 0. 
    // if count is greater than min, the item is usable. Otherwise, it isn't. 
    // Basically, you can't use an item if you have 0 of the item. 
    public bool IsUsable()
    {
        return count > recipe.itemCountRange.minValue ? true : false;
    }

    /**
     * <summary>Updates item's internal count.</summary>
     * <param name="amount">Number to change item count by.</param>
     */
    public void UpdateCount(int amount)
    {
        int newCount = count + amount;
        ResourceType itemCountRange = recipe.itemCountRange;
        if (newCount < itemCountRange.maxValue && newCount > itemCountRange.minValue)
        {
            // New count is in correct bounds, update it
            count = newCount;
        }
        else if (newCount < itemCountRange.maxValue)
        {
            // Count dipping below min value, set to min
            count = itemCountRange.minValue;
        }
        else
        {
            // Count over max value, set to max
            count = itemCountRange.maxValue;
        }
    }
    /***************************************************************************
     * Item Recipe defined methods
     **************************************************************************/
    /**
     * <summary>Use item on user</summary>
     * <param name="user">Unit using item</param>
     */

    //This is the method we'd use for the Item button
    public void UseItem(UnitController user)
    {
        UnityEngine.Debug.Log("UseItem() ");
        if (IsUsable())
        {
            // Have enough of item, use it
            int numUsed = recipe.UseItem(user);
            // Update item count based off number used
            UpdateCount(numUsed * -1);
        }
    }

    /**
     * <summary>Use item on target(s)</summary>
     * <param name="user">Unit using item</param>
     * <param name="target">Item's targets</param>
     */
    public void UseItem(UnitController user, List<UnitController> targets)
    {
        if (IsUsable())
        {
            // Have enough of item, use it
            int numUsed = recipe.UseItem(user, targets);
            // Update item count based off number used
            UpdateCount(numUsed * -1);
        }

    }

    /**
     * <summary>Render item icon</summary>
     */
    public void RenderItem()
    {
        recipe.RenderItem();
    }
}
