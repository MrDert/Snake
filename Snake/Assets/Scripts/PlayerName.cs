using UnityEngine;
using Mirror;
using TMPro;


public class PlayerName : NetworkBehaviour
{
    [SerializeField] private TMP_Text _playerNameText;
    [SyncVar(hook = nameof(HandlePlayerNameUpdated))] private string _playerName;

    private void HandlePlayerNameUpdated(string oldText, string newText)
    {
        _playerNameText.text = newText;
    }
    public override void OnStartServer()
    {
        _playerName = $"Player {connectionToClient.connectionId+1}";
    }
}
