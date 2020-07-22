using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SortedMap<TKey, TValue> : ISerializationCallbackReceiver
{
    public SortedDictionary<TKey, TValue> dictionary = new SortedDictionary<TKey, TValue>();
    public List<TKey> keys = new List<TKey>();
    public List<TValue> values = new List<TValue>();

    public void OnBeforeSerialize()
    {
        // Serialize dictionary into two lists
        //keys.Clear();
        //values.Clear();
        foreach(KeyValuePair<TKey, TValue> kvp in dictionary) {
            keys.Add(kvp.Key);
            values.Add(kvp.Value);
        }
    }

    public void OnAfterDeserialize()
    {
        // Deserialize lists back into a dictionary
        dictionary.Clear();
        for(int i = 0; i < keys.Count; i++)
        {
            UnityEngine.Debug.Log("key: " + keys[i] + ", value: " + values[i]);
            dictionary.Add(keys[i], values[i]);
        }
    }

}

[System.Serializable]
public class ItemRecipeMap : SortedMap<string, ItemRecipe>
{
}