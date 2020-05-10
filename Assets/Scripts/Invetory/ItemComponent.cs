
using UnityEngine;

public abstract class ItemComponent : MonoBehaviour
{
    public bool CanUse => Time.time >= _nextUseTime;

    protected float _nextUseTime;

    public abstract void Use();

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space) && CanUse)
    //    {
    //        Use();
    //        _nextUseTime = Time.time + 1f;
    //    }
    //}
            


    
   
        

}
