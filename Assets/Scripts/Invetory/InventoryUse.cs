using UnityEngine;


[RequireComponent(typeof(Inventory))]
public class InventoryUse : MonoBehaviour
{
    private Inventory _inventory;

    private void Awake()
    {
        _inventory = GetComponent<Inventory>();
    }
    private void Update()
    {
        if(_inventory.ActiveItem == null || _inventory.ActiveItem.Actions == null)
            return;

        foreach (var useAction in _inventory.ActiveItem.Actions)
        {
            if (useAction.TargetComponent.CanUse && WasPressed(useAction.UseMode))
            {
                useAction.TargetComponent.Use();
            }
        }
    }


    // this will check for when the buttons you have setup as input for given item is pressed, and will return true when it is pressed.
    private bool WasPressed(UseMode useMode)
    {
        switch (useMode)
        {
            case UseMode.LeftClick:
                return Input.GetMouseButtonDown(0);
                break;
            case UseMode.RigthClick:
                return Input.GetMouseButtonDown(1);
                break;
            default:
                return false;
                break;
        }
    }
}
