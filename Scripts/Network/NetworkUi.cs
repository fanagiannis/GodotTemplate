using Godot;
using System;

public partial class NetworkUi : Control
{
	[Export]
	NetworkHandler networkHandler;
	public void OnServerPressed()
	{
		networkHandler.StartServer();
	}

	public void OnClientPressed()
	{
		networkHandler.StartClient();
	}
}
