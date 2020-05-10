using System;

[Serializable]
public struct UseAction
{
    public UseMode UseMode;

    // Script to run like itemRaycaster etc
    public ItemComponent TargetComponent;
}
