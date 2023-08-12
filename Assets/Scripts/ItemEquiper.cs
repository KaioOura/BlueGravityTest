using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEquiper : MonoBehaviour
{
    public event Action<int, AnimationsPack> OnItemEquipUpdateAnimations;
    public Equipment Equipment;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EquipItem(Equipment);
        }
    }

    void EquipItem(Equipment equipment)
    {
        //Communicate others systems that an item has been equipped
        
        OnItemEquipUpdateAnimations?.Invoke((int)equipment.EquipmentType, equipment.AnimationsPack);
        
    }
}
