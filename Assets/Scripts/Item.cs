using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    // Item's default property values from its recipe
    public ItemRecipe recipe;
    public string itemName { get { return recipe.itemName; } }
    public string itemDescription { get { return recipe.itemDescription; } }

    // Keep track of Item's per instance properties
    public int quantity { get; set; } = 0;

    /***************************************************************************
     * Item Recipe defined methods
     **************************************************************************/
    /**
     * <summary>Use item on user</summary>
     * <param name="user">Unit using item</param>
     */
    public void UseItem(UnitController user)
    {
        int numUsed = recipe.UseItem(user);
    }

    /**
     * <summary>Use item on target(s)</summary>
     * <param name="user">Unit using item</param>
     * <param name="target">Item's targets</param>
     */
    public void UseItem(UnitController user, List<UnitController> targets)
    {
        int numUsed = recipe.UseItem(user, targets);
    }

    /**
     * <summary>Render item icon</summary>
     */
    public void RenderItem()
    {
        recipe.RenderItem();
    }
}
