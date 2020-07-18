using UnityEngine;

[CreateAssetMenu(fileName = "ResourceType", menuName = "Type/Resource")]
public class ResourceType : ScriptableObject
{
    public int minValue;
    public int maxValue;
    public int defaultValue;
}
