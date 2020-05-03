using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _chareacterController;
    public IPlayerInput PlayerInput { get; set; } = new PlayerInput();

    private void Awake()
    {
        _chareacterController = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 movementInput = new Vector3(PlayerInput.Horizontal, 0, PlayerInput.Vertical);

        //TODO: fig out why this is correct
        Vector3 movement = transform.rotation * movementInput;
        _chareacterController.SimpleMove(movement);
    }
}

public class PlayerInput: IPlayerInput
{
    public float Vertical => Input.GetAxis("Vertical");
    public float Horizontal => Input.GetAxis("Horizontal");
    
    
}

public interface IPlayerInput
{
     float Vertical { get; }
     float Horizontal { get; }
}