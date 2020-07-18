using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    // Item's default property values from its recipe
    private ItemRecipe recipe;
    private ValueRangeType itemCountRange;
    public string itemName { get { return recipe.itemName; } }
    public string itemDescription { get { return recipe.itemDescription; } }

    // Keep track of Item's per instance properties
    public int count { get; set; }

    public Item(ItemRecipe recipe, ValueRangeType itemCountRange, int count = 0)
    {
        this.recipe = recipe;
        this.itemCountRange = itemCountRange;
        this.count = count;
    }

    /***************************************************************************
     * Item Instance methods
     **************************************************************************/
    /**
     * <returns>Whether item is usable or not.</returns>
     */
    public bool IsUsable()
    {
        return count > itemCountRange.minValue ? true : false;
    }

    /**
     * <summary>Updates item's internal count.</summary>
     * <param name="amount">Number to change item count by.</param>
     */
    public void UpdateCount(int amount)
    {
        int newCount = count + amount;
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
    public void UseItem(UnitController user)
    {
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
