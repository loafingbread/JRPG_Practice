using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Inventory")]
public class Inventory : ScriptableObject
{
    public int money;
    public List<ItemRecipe> itemRecipes = new List<ItemRecipe>();
    public ItemRecipe itemRecipe;
    public Item item;
    [SerializeField]
    public ItemRecipeMap consumables = new ItemRecipeMap();    
}
