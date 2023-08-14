using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Transform _container;
    
    [SerializeField] private ShopTab _hairTab;
    [SerializeField] private ShopTab _hatTab;
    [SerializeField] private ShopTab _bottomTab;
    [SerializeField] private ShopTab _fullBodyTab;

    [SerializeField] private CanvasGroup[] _canvasGroups;

    private bool _isOpen;

    private void Awake()
    {
        _container.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    public virtual void Start()
    {

    }

    public virtual void OnDestroy()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenTab(CanvasGroup canvasGroup)
    {
        for (int i = 0; i < _canvasGroups.Length; i++)
        {
            if (canvasGroup != _canvasGroups[i])
            {
                _canvasGroups[i].alpha = 0;
                _canvasGroups[i].interactable = false;
                _canvasGroups[i].blocksRaycasts = false;
            }
        }

        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    public void CloseInventory()
    {
        _container.gameObject.SetActive(false);
    }
    
    public void OpenInventory(List<Item> items, Action<Item> buttonAction)
    {
        _container.gameObject.SetActive(true);
        PopulateTabs(items, buttonAction);
    }

    public virtual void PopulateTabs(List<Item> items, Action<Item> tryBuyItem)
    {
        List<Equipment> equipmentList = new List<Equipment>();
        List<Item> hairList = new List<Item>();
        List<Item> hatList = new List<Item>();
        List<Item> bottomList = new List<Item>();
        List<Item> fullBodyList = new List<Item>();

        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].ItemType == ItemType.Equipment)
            {
                equipmentList.Add(items[i] as Equipment);
            }
        }

        for (int i = 0; i < equipmentList.Count; i++)
        {
            switch (equipmentList[i].EquipmentType)
            {
                case EquipmentType.Hair:
                {
                    hairList.Add(equipmentList[i]);
                    break;
                }
                case EquipmentType.Hat:
                    hatList.Add(equipmentList[i]);
                    break;
                case EquipmentType.Upper:
                    
                    break;
                case EquipmentType.Bottom:
                    bottomList.Add(equipmentList[i]);
                    break;
                case EquipmentType.FullBody:
                    fullBodyList.Add(equipmentList[i]);
                    break;
            }
        }
        
        _hairTab.PopulateShop(hairList, tryBuyItem);
        _hatTab.PopulateShop(hatList, tryBuyItem);
        _bottomTab.PopulateShop(bottomList, tryBuyItem);
        _fullBodyTab.PopulateShop(fullBodyList, tryBuyItem);
    }
}
