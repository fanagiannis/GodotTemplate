using Godot;
using System;

public partial class PlayerSpawner : MultiplayerSpawner
{
    [Export]
    private PackedScene networkPlayer { get; set; }
    public override void _Ready()
    {
        Multiplayer.PeerConnected += SpawnPlayer;

    }

    private void SpawnPlayer(long id)
    {
        if (!Multiplayer.IsServer())
            return;

        var player = networkPlayer.Instantiate();
        player.Name = id.ToString();
        GetNode(SpawnPath).CallDeferred("add_child",player);
    }

}
