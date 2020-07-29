using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryDefaults", menuName = "Defaults/Inventory")]
public class InventoryDefaults : ScriptableObject
{
    public List<ItemRecipe> itemRecipes = new List<ItemRecipe>();
    public List<int> itemCounts = new List<int>();
}
