using System.Collections.Generic;
using UnityEngine;

/**
 * <summary>Base item asset template to subclass all other item assets
 * from.</summary>
 */
public abstract class Item : ScriptableObject
{
    public string itemName;
    public string itemDescription;
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
}
