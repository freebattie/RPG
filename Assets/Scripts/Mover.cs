using UnityEngine;
using UnityEngine.AI;
public class Mover : IMover
{
    private readonly Player _player;
    private readonly CharacterController _chareacterController;

    public Mover(Player player)
    {
        this._player = player;
        _chareacterController = _player.GetComponent<CharacterController>();
        _player.GetComponent<NavMeshAgent>().enabled = false;
    }
    public void Tick()
    {
        Vector3 movementInput = new Vector3(_player.PlayerInput.Horizontal, 0, _player.PlayerInput.Vertical);
        //TODO: fig out why this is correct
        Vector3 movement = _player.transform.rotation * movementInput;
        _chareacterController.SimpleMove(movement);
    }
}
