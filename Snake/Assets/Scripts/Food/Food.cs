using UnityEngine;
using Mirror;
using System;

public class Food : NetworkBehaviour
{
    [SerializeField] GameObject particlePrefab;
    private GameObject boom;
    public static event Action<GameObject> ActionServerOnFoodEaten;
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        ActionServerOnFoodEaten?.Invoke(other.gameObject);
        ServerParticle();
        NetworkServer.Destroy(gameObject);
    }
    private void DestroyParticle()
    {
        NetworkServer.Destroy(boom);
        Destroy(boom);
    }
    [ServerCallback]
    private void ServerParticle()
    {
        boom = Instantiate(particlePrefab, transform.position, particlePrefab.transform.rotation);
        NetworkServer.Spawn(boom);
        Invoke("DestroyParticle", 3f);
    }
}
