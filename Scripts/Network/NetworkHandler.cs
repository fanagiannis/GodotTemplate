using Godot;
using System;



public partial class NetworkHandler : Node
{
	const string IP_ADDRESS = "Localhost";
	const int PORT = 42069;

	public void StartServer()
	{
		var peer = new ENetMultiplayerPeer();
		peer.CreateServer(PORT);
		Multiplayer.MultiplayerPeer = peer;
	}

	public void StartClient()
	{
		var peer = new ENetMultiplayerPeer();
		peer.CreateClient(IP_ADDRESS, PORT);
		Multiplayer.MultiplayerPeer = peer;
	}
}
