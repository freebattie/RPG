
using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //TESTING
    public  event Action<Item> ActiveItemChanged;

    [SerializeField] private Transform _rightHand;
    private List<Item> _items = new List<Item>();
    private Transform _itemRoot;

    public Item ActiveItem { get; private set; }
   
    

    
    private void Awake()
    {
        _itemRoot = new GameObject("Items").transform;
        _itemRoot.SetParent(transform);
    }
    internal void Pickup(Item item)
    {
        _items.Add(item);
        item.transform.SetParent(_itemRoot);

        Equip(item);

    }
    
    //TODO: remove, also remove test.
    public Item GetItem(Item item)
    {
        if (_items.Contains(item))
        {
            return item;
        }
        return null;
    }
    private void Equip(Item item)
    {
        
        item.transform.SetParent(_rightHand);
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;
        ActiveItem = item;

        // ? used to check for null
        ActiveItemChanged?.Invoke(ActiveItem);
    }
}
