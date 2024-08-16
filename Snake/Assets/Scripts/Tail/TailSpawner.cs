using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class TailSpawner : NetworkBehaviour
{
    [SerializeField] private GameObject _talePrefab;
    public List<GameObject> Tails { get; } = new List<GameObject>();
    public override void OnStartServer()
    {
        Food.ActionServerOnFoodEaten += AddTale; 
    }
    public override void OnStopServer()
    {
        Food.ActionServerOnFoodEaten -= AddTale;
    }
    private void AddTale(GameObject player)
    {
        if (player != gameObject) return;
        var tale = Instantiate(_talePrefab, Tails.Count == 0 ? transform.position : Tails[Tails.Count - 1].transform.position, Quaternion.identity);
        NetworkServer.Spawn(tale, connectionToClient);
    }
}
