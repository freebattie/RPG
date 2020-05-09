using UnityEngine;
using UnityEngine.AI;

public class NavmeshMover : IMover
{
    private readonly Player _player;
    private readonly NavMeshAgent _navMeshAgent;
    

    public NavmeshMover(Player player)
    {
        this._player = player;
        _navMeshAgent = _player.GetComponent<NavMeshAgent>();
        if (_navMeshAgent)
        {
            _navMeshAgent.enabled = true;
        }
        else
        {
            Debug.Log("WTF");
        }
        
    }

    public void Tick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out var hitInfo))
            {
                _navMeshAgent.SetDestination(hitInfo.point);
            }
        }
    }
}
