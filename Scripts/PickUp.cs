using Godot;
using System;
using System.Diagnostics;

public partial class PickUp : Area3D
{
	public enum itemType
	{
		Health,
		Ammo,
		Weapon
	};

	[Export]
	private itemType item;
	[Export]
	private PackedScene itemInstance;
	[Export]
	private float value; //OPTIONAL
	public void OnBodyEntered(Node3D body)
	{
		if (body.GetParent().IsInGroup("Player"))
		{
			Player player = body.GetParent() as Player;
			GD.Print(player);
			switch (item)
			{
				case itemType.Health:
					player.Heal(value);
					QueueFree();
					return;
				case itemType.Ammo:
					QueueFree();
					return;
				case itemType.Weapon:
					GD.Print("weapon");
					return;
			}

		}
	}
}
