using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SnakeNetworkManager : NetworkManager
{
    [SerializeField] private GameObject _foodSpawnerPrefab;
    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);
        if (numPlayers != 2) return;
        var foodSpawner = Instantiate(_foodSpawnerPrefab);
        NetworkServer.Spawn(foodSpawner);
    }
}
