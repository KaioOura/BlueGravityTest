using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEquiper : MonoBehaviour
{
    public event Action<int, AnimationsPack> OnItemEquipUpdateAnimations;
    // public Equipment Equipment;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //EquipItem(Equipment);
        }
    }

    public void EquipItem(Item item)
    {
        //Communicate others systems that an item has been equipped
        
        Equipment equipment = item as Equipment; 
        
        if (equipment == null)
            return;
        
        OnItemEquipUpdateAnimations?.Invoke((int)equipment.EquipmentType, equipment.AnimationsPack);
        
    }
}
