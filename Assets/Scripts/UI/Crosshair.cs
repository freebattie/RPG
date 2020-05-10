using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    private Image _crosshairImage;

    [SerializeField] private Sprite _invalidSprite;

    private Inventory _inventory;

    private void OnEnable()
    {
        _inventory = FindObjectOfType<Inventory>();
        _inventory.ActiveItemChanged += HandelActiveItemChanged;
        _crosshairImage.sprite = _invalidSprite;

        if (_inventory != null)
            HandelActiveItemChanged(_inventory.ActiveItem);
    }
    private void OnValidate()
    {
        _crosshairImage = GetComponent<Image>();
    }

    private void HandelActiveItemChanged(Item item)
    {
       if(item != null && item.CrosshairDefinition != null)
        {
            _crosshairImage.sprite = item.CrosshairDefinition.Sprite;
        }
        else
        {
            _crosshairImage.sprite = _invalidSprite;
        }
    }
}
