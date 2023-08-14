using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MagicDesk : MonoBehaviour
{
    [SerializeField] private GameObject _mugPrefab;
    
    [SerializeField] private Vector2 spawnTimeRange;

    [SerializeField] private Inventory _playerInventory;

    [SerializeField] private TextMeshProUGUI _coinFeedback;
    [SerializeField] private Image _coinImage;

    private IEnumerator _spawnCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MugSpawnCoroutine((int)Random.Range(spawnTimeRange.x, spawnTimeRange.y)));
    }
    
    public void OnMugPickUp()
    {
        if (!_mugPrefab.activeSelf)
            return;
        
        _mugPrefab.SetActive(false);

        int valueToAdd = Random.Range(10, 30);
        
        _playerInventory.AddCoins(valueToAdd);
        _coinFeedback.text = valueToAdd.ToString();
        
        _coinFeedback.DOFade(1, 0.1f);
        _coinImage.DOFade(1, 0.1f).OnStepComplete(() =>
        {
            _coinFeedback.transform.DOLocalMoveY(20, 1);
            _coinFeedback.DOFade(0, 1f);
            _coinImage.DOFade(0, 1);
        });

        
        if (_spawnCoroutine != null)
            StopCoroutine(_spawnCoroutine);

        _spawnCoroutine = MugSpawnCoroutine((int)Random.Range(spawnTimeRange.x, spawnTimeRange.y));
        StartCoroutine(_spawnCoroutine);

    }

    IEnumerator MugSpawnCoroutine(int timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        
        _coinFeedback.transform.DOLocalMoveY(0, 0);

        _mugPrefab.SetActive(true);
    }
}
