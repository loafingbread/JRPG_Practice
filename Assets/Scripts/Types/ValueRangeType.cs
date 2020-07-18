using UnityEngine;

[CreateAssetMenu(fileName = "MinMaxValue", menuName = "Type/ValueRange")]
public class ValueRangeType : ScriptableObject
{
    public int defaultValue;
    public int maxValue;
    public int minValue;
}
