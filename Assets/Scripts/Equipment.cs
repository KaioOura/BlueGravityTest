using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EquipmentData", menuName = "ScriptableObjects/Equipment", order = 2)]
public class Equipment : Item
{
    [SerializeField] private EquipmentType _equipmentType;

    public EquipmentType EquipmentType => _equipmentType;
}

public enum EquipmentType
{
    Hair,
    Hat,
    Upper,
    Bottom,
    FullBody
}
