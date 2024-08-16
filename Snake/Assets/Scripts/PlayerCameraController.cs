using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerCameraController : NetworkBehaviour
{
    [SerializeField] private GameObject _cam;
    public override void OnStartAuthority()
    {
        _cam.SetActive(true);
    }
}
