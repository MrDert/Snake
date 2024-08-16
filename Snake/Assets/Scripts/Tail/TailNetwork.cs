using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class TailNetwork : NetworkBehaviour
{
    [SyncVar] private Snake _owner;
    [SyncVar] private GameObject _tailTarget;
    public Snake Owner
    {
        get { return _owner; }
        private set { _owner = value; }
    }
    public GameObject TailTarget
    {
        get { return _tailTarget; }
        private set { _tailTarget = value; }
    }
    public override void OnStartServer()
    {
        Owner = connectionToServer.identity.GetComponent<Snake>();
        var tails = Owner.GetComponent<TailSpawner>().Tails;
        TailTarget = tails.Count == 0 ? Owner.gameObject : tails[tails.Count - 1];
        tails.Add(gameObject);
    }
}
