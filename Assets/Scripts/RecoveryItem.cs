using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="RecoveryItem", menuName = "Items/Recovery")]
public class RecoveryItem : Item
{
    public int value;
    public ResourceType type;

    public override int UseItem(UnitController user)
    {
        if (type.name == "HealthPoints")
        {
            // Heal user's health points
            user.currentHP = Recover(user.currentHP, user.maxHP);
        } else if (type.name == "ManaPoints")
        {
            // Heal user's mana points
            user.currentMP = Recover(user.currentMP, user.maxMP);
        }
        return 1;
    }

    private int Recover(int currentValue, int maxValue)
    {
        // Recover current value by item value, capped at maxValue
        currentValue += value;
        if (currentValue > maxValue)
        {
            currentValue = maxValue;
        }

        return currentValue;
    }

    public override int UseItem(UnitController user, List<UnitController> targets)
    {
        foreach(UnitController target in targets)
        {
            // Use item on each target
            UseItem(target);
        }
        return 1;
    }
}
