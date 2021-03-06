﻿using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

/**
 * <summary>Base item asset template to subclass all other item assets
 * from.</summary>
 */
public abstract class ItemRecipe : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public int itemCost;
    public GameObject itemPrefab;
    public ResourceType itemCountRange;
    public ItemRecipeSet itemRecipes;

    protected void OnEnable()
    {
        if (itemRecipes)
        {
            itemRecipes.Add(this);
        }
    }

    /**
     * <summary>On disable (usually when destroyed/out of scope), remove
     * item recipe from shared list of item recipes.</summary>
     */
    protected void OnDisable()
    {
        if (itemRecipes)
        {
            itemRecipes.Remove(this);
        }
    }

    /**
     * <summary>Use item on user.</summary>
     * <param name="user">Object that will use item.</param>
     * <returns>Number of items used.</returns>
     */
    public abstract int UseItem(UnitController user);

    /**
     * <summary>Have user use item(s) on target(s).</summary>
     * <param name="user">Object that will use item(s).</param>
     * <param name="targets">Target(s) to use items on.</param>
     * <returns>Number of items used.</returns>
     */
    public abstract int UseItem(UnitController user, List<UnitController> targets);

    /** 
     * <summary>Render item into scene.</summary>
     */
     public virtual void RenderItem()
    {
        Instantiate(itemPrefab);
    }

    public int ItemCost(int desiredAmount)
    {
        return desiredAmount * itemCost;
        
    }

}
