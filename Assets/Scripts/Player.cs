using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _chareacterController;
    private IMover _mover;

    private Rotator _rotator;
    public IPlayerInput PlayerInput { get; set; } = new PlayerInput();

    private void Awake()
    {
        _chareacterController = GetComponent<CharacterController>();
        _mover = new Mover(this);
        _rotator = new Rotator(this);
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
            _mover = new NavmeshMover(this);
        if (Input.GetKeyDown(KeyCode.Alpha1))
            _mover = new Mover(this);

        _mover.Tick();
        _rotator.Tick();
    }
}
