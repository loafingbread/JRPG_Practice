using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RuntimeSet<T> : ScriptableObject
{
    public List<T> values = new List<T>();

    public void Add(T value)
    {
        if (!values.Contains(value))
        {
            // Value not in set yet, add it
            values.Add(value);
        }
    }

    public void Remove(T value)
    {
        if (values.Contains(value))
        {
            // Value is in set, remove it
            values.Remove(value);
        }
    }
}