using Godot;
using Godot.Collections;
using System;

public partial class PlayerSpawner : MultiplayerSpawner
{
    [Export]
    private PackedScene networkPlayer { get; set; }
    [Export]
    private Array<Node3D> spawnPoints;
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
        GetNode(SpawnPath).CallDeferred("add_child", player);
        Node3D playerNode = player as Node3D;
        playerNode.GlobalPosition = spawnPoints[0].GlobalPosition;
        NetworkPlayer nPlayer = playerNode as NetworkPlayer;
        nPlayer.SetID(spawnPoints.Count-1);
        spawnPoints.RemoveAt(0);
    }

}
