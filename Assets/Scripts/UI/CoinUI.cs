using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinText;
    [SerializeField] private Inventory _playerInventory;
    
    // Start is called before the first frame update
    void Start()
    {
        _playerInventory.OnCoinsUpdate += UpdateCoinDisplay;
        
        UpdateCoinDisplay(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCoinDisplay(int coin)
    {
        _coinText.text = coin.ToString();
    }
}
